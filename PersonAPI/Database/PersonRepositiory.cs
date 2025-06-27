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

	private string AddWhereEquals(string name, object value, SQLiteCommand command)
	{
		command.Parameters.AddWithValue($"@{name}", value);
		return $"{name} = @{name}";
	}

	public IEnumerable<Person> Search(PersonSearchParameters parameters)
	{
		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(connection);
		string sqlquery = $@"SELECT * FROM {TABLENAME} WHERE";

		if (parameters.FirstName is not null)
			sqlquery += AddWhereEquals("firstName", parameters.FirstName, command);

		if (parameters.LastName is not null)
			sqlquery += AddWhereEquals("lastName", parameters.LastName, command);

		if (parameters.Age is not null)
			sqlquery += AddWhereEquals("age", parameters.Age, command);

		if (parameters.DayOfBirth is not null)
			sqlquery += AddWhereEquals("dayOfBirth", parameters.DayOfBirth, command);

		
		command.CommandText = sqlquery;

		return _dbModules.ReadAll(command.ExecuteReader(), Read);
	}
}