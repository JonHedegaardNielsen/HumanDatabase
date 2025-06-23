using Microsoft.AspNetCore.SignalR;
using System.Data.SQLite;

namespace API.Database
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
