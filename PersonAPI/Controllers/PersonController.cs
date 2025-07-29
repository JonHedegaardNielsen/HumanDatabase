using PersonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonAPI.Database;
using PersonAPI.Enums;

namespace PersonAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
	private readonly ILogger<PersonController> _logger;
	private readonly PersonRepositiory _repository = new();
	public PersonController(ILogger<PersonController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public IEnumerable<Person> Get()
	{
		return _repository.GetAll();
	}

	[HttpGet("single{personId}")]
	public ActionResult<Person> GetById(int id)
	{
		Person? person =_repository.GetSingle(id);

		return person is not null ? Ok(person) : BadRequest();
	}

	[HttpDelete("{id}")]
	public ActionResult Delete(int id)
	{
		try
		{
			_repository.Delete(id);
			return Ok();
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpPost]
	public ActionResult Post([FromBody]Person person)
	{
		try
		{
			_repository.Create(person);
			return Ok();
		}
		catch
		{
			return BadRequest();
		}
	}

	[HttpGet("SearchPerson/SearchParams")]
	public IEnumerable<Person> GetPersonSearch([FromQuery]string? firstName, [FromQuery] string? lastName, [FromQuery] int? age, [FromQuery] int? gender, [FromQuery] int? height, [FromQuery] int? weight, [FromQuery] DateOnly? dayOfBirth)
	{
		return _repository.Search(new(firstName, lastName, age, (Genders?)gender, height, weight, dayOfBirth));
	}
}
