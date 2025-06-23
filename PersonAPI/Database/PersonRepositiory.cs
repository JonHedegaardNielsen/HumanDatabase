using PersonAPI.Models;
using System.Data.SQLite;

namespace PersonAPI.Database
{
	public class PersonRepositiory
	{
		private readonly CommonDBModules _dbModules = new();
		public Person GetSingle(int id)
		{
			string sqlquery = $@"";

			using SQLiteConnection connection = _dbModules.GetConnection();
			using SQLiteCommand command = new(connection);

			throw new NotImplementedException("SQL query not implemented yet");
		}

		public IEnumerable<Person> GetAll()
		{
			throw new NotImplementedException("SQL query not implemented yet");
		}
	}
}
