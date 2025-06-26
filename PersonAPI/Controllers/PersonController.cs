using PersonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonAPI.Database;

namespace PersonAPI.Controllers
{
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

		[HttpDelete]
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
	}


}
