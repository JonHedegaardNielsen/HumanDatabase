using API.Enums;

namespace API.Models
{
	public record Person(string FirstName, string LastName, DateOnly DayOfBirth, Genders Gender, int Weight, int Height);
}
