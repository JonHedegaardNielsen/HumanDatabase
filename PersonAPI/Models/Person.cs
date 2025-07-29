using PersonAPI.Enums;

namespace PersonAPI.Models
{
	public record Person(int PersonId,
		string FirstName,
		string LastName,
		int Age,
		Genders Gender,
		int Height,
		int Weight,
		DateOnly DayOfBirth,
		string? Base64Image = null
		);
}
