using PersonAPI.Enums;
using PersonAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;

namespace PersonAPI.Database;

public class PersonRepositiory : IRepository<Person>
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

	public void Update(Person person)
	{
		string sqlquery = $@"UPDATE {TABLENAME} 
					SET firstName = @firstName, lastName = @lastName, age = @age, gender = @gender, 
					height = @height, weight = @weight, dayOfBirth = @dayOfBirth";

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

	private void AddWhereEquals(string name, object value, SQLiteCommand command, ref string sqlQuery)
	{
		command.Parameters.AddWithValue($"@{name}", value);
		sqlQuery += $"{name} = @{name}";
		sqlQuery += " AND ";
	}

	private void AddWhereEqualsIfNotNull(string name, object? value, SQLiteCommand command, ref string sqlQuery)
	{
		if (value is not null)
		{
			AddWhereEquals(name, value, command, ref sqlQuery);
		}
	}


	public IEnumerable<Person> Search(PersonSearchParameters parameters)
	{
		using SQLiteConnection connection = _dbModules.GetConnection();
		using SQLiteCommand command = new(connection);
		string sqlquery = $@"SELECT * FROM {TABLENAME} WHERE ";

		AddWhereEqualsIfNotNull("firstName", parameters.FirstName, command, ref sqlquery);
		AddWhereEqualsIfNotNull("lastName", parameters.LastName, command, ref sqlquery);
		AddWhereEqualsIfNotNull("age", parameters.Age, command, ref sqlquery);
		AddWhereEqualsIfNotNull("dayOfBirth", parameters.DayOfBirth, command, ref sqlquery);
		AddWhereEqualsIfNotNull("gender", parameters.Gender, command, ref sqlquery);
		AddWhereEqualsIfNotNull("weight", parameters.Weight, command, ref sqlquery);
		AddWhereEqualsIfNotNull("height", parameters.Height, command, ref sqlquery);

		const int ANDPOSITION = 4;
		const int WHEREPOSITION = 6;

		if (sqlquery[^ANDPOSITION..] == "AND ")
		{
			sqlquery = sqlquery.Remove(sqlquery.Length - ANDPOSITION);
		}

		if (sqlquery[^6..] == "WHERE ")
		{
			sqlquery = sqlquery.Remove(sqlquery.Length - WHEREPOSITION);
		}

		command.CommandText = sqlquery;

		return _dbModules.ReadAll(command.ExecuteReader(), Read);
	}
}