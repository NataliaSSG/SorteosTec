using Microsoft.AspNetCore.Mvc;
using TecTrekAPI.Models;
using TecTrekAPI.Services;

namespace TecTrekAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SessionDataController : ControllerBase
	{
		private readonly SessionDataService _sessionDataService;

		public SessionDataController(SessionDataService sessionDataService)
		{
			_sessionDataService = sessionDataService;
		}

		[HttpGet]
		public ActionResult<SessionDataModel> GetSessionData()
		{
			return _sessionDataService.GetSessionData();
		}

		[HttpPost]
		public ActionResult SetSessionData(SessionDataModel sessionData)
		{
			_sessionDataService.SetSessionData(sessionData);
			return Ok();
		}
	}
}