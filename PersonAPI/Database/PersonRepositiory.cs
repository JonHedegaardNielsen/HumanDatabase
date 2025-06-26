using PersonAPI.Enums;
using PersonAPI.Models;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;

namespace PersonAPI.Database;

public class PersonRepositiory
{
	private readonly CommonDBModules _dbModules = new();
	private const string TABLENAME = "person";
	private const string IDNAME = "personId";
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
			DateOnly.FromDateTime(DateTime.Parse(reader.GetString(7)))
		);
	}

	public Person? GetSingle(int id)
	{
		string sqlquery = $@"SELECT TOP(1) * FROM {TABLENAME}
					WHERE {IDNAME} = @{nameof(id)}";

		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(sqlquery, connection);
		command.Parameters.AddWithValue($"@{nameof(id)}", id);

		return _dbModules.ReadSingle(command.ExecuteReader(), Read);
	}

	public IEnumerable<Person> GetAll()
	{
		string sqlquery = $"SELECT * FROM {TABLENAME}";

		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(sqlquery, connection);

		return _dbModules.ReadAll(command.ExecuteReader(), Read);
	}

	public void Delete(int id)
	{
		string sqlquery = $@"DELETE FROM {TABLENAME}
					WHERE {IDNAME} = @{nameof(id)}";
		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(sqlquery, connection);
		command.Parameters.AddWithValue($"@{nameof(id)}", id);
		command.ExecuteNonQuery();
	}

	public void Create(Person person)
	{
		string sqlquery = $@"INSERT INTO {TABLENAME} 
					(firstName, lastName, age, gender, height, personWeight, dayOfBirth)
					VALUES (@firstName, @lastName, @age, @gender, @height, @weight, @dayOfBirth)";
		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(sqlquery, connection);
		command.Parameters.AddWithValue("@firstName", person.FirstName);
		command.Parameters.AddWithValue("@lastName", person.LastName);
		command.Parameters.AddWithValue("@age", person.Age);
		command.Parameters.AddWithValue("@gender", (int)person.Gender);
		command.Parameters.AddWithValue("@height", person.Height);
		command.Parameters.AddWithValue("@weight", person.Weight);
		command.Parameters.AddWithValue("@dayOfBirth", person.DayOfBirth);
		command.ExecuteNonQuery();
	}
}