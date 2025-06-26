using PersonAPI.Enums;

namespace PersonAPI.Models
{
	// not finished yet
	public record PersonSearchParameters(int? PersonId,
		string? FirstName,
		string? LastName,
		int? Age,
		Genders? Gender,
		int? Height,
		int? Weight,
		DateOnly? DayOfBirth

		);
}
