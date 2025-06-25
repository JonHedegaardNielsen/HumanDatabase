using PersonAPI.Enums;
using PersonAPI.Models;
using System.Data.SQLite;

namespace PersonAPI.Database
{
	public class PersonRepositiory
	{
		private readonly CommonDBModules _dbModules = new();
		private const string TABLENAME = "person";

		private Person Read(SQLiteDataReader reader)
		{
			return new Person(
				reader.GetInt32(0),
				reader.GetString(1),
				reader.GetString(2),
				reader.GetInt32(3),
				(Genders)reader.GetInt32(4),
				reader.GetInt32(5),
				reader.GetInt32(6),
				DateOnly.FromDateTime(reader.GetDateTime(7))
			);
		}

		public Person? GetSingle(int id)
		{
			string sqlquery = $@"SELECT TOP(1) * FROM {TABLENAME}
					WHERE personId = @{nameof(id)}";

			using SQLiteConnection connection = _dbModules.GetConnection();
			using SQLiteCommand command = new(connection);
			command.Parameters.AddWithValue($"@{nameof(id)}", id);

			return _dbModules.ReadSingle(command.ExecuteReader(), Read);
		}

		public IEnumerable<Person> GetAll()
		{
			throw new NotImplementedException("SQL query not implemented yet");
		}
	}
}
