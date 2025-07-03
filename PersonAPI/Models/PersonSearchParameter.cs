using PersonAPI.Enums;

namespace PersonAPI.Models
{
	public record PersonSearchParameters(string? FirstName,
		string? LastName,
		int? Age,
		Genders? Gender,
		int? Height,
		int? Weight,
		DateOnly? DayOfBirth
	);
}
