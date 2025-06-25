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


	}


}
