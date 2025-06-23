using PersonAPI.Enums;

namespace PersonAPI.Models
{
	public record Person(string FirstName, string LastName, DateOnly DayOfBirth, Genders Gender, int Weight, int Height);
}
