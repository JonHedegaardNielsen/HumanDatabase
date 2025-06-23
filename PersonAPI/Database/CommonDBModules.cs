using Microsoft.AspNetCore.SignalR;
using System.Data.SQLite;

namespace PersonAPI.Database
{
	public class CommonDBModules
	{
		private static string ConnectionString => $"Data Source={_databasePath};";
		private const string _databasePath = "Database/database.db";
		private const string _setupscriptPath = "Database/Setup.sql";

		public SQLiteConnection GetConnection()
		{
			SQLiteConnection conn = new(ConnectionString);
			conn.Open();
			return conn;
		}

		public Type? ReadSingle<Type>(SQLiteDataReader reader, Func<SQLiteDataReader, Type> getValue)
		{
			if (reader.Read())
			{
				return getValue(reader);
			}

			return default;
		}

		public IEnumerable<Type> ReadAll<Type>(SQLiteDataReader reader, Func<SQLiteDataReader, Type> getValue)
		{
			List<Type> result = [];

			while (reader.Read())
			{
				result.Add(getValue(reader));
			}

			return result;
		}

		public void CreateDatabaseIfNotExists()
		{
			if (File.Exists(_databasePath)) return;

			SQLiteConnection.CreateFile(_databasePath);

			string sqlSetupString = File.ReadAllText(_setupscriptPath);
			using SQLiteConnection conn = GetConnection();
			using SQLiteCommand cmd = new(sqlSetupString, conn);
			cmd.ExecuteNonQuery();
		}
	}
}
