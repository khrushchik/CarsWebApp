using CarsWebApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramApiController : ControllerBase
    {
		private readonly TelegramApiService _tegramApiService;

		public TelegramApiController(TelegramApiService tegramApiService) => _tegramApiService = tegramApiService;

		[HttpGet("status")]
		public ActionResult Status()
		{
			switch (_tegramApiService.ConfigNeeded)
			{
				case "connecting": return NotFound("WTelegram is connecting...");
				case null: return Ok($@"Connected as {_tegramApiService.User}");
				default: return NotFound($"need enter {_tegramApiService.ConfigNeeded}");
			}
		}

		[HttpGet("config")]
		public async Task<ActionResult> Config(string value)
		{
			await _tegramApiService.DoLogin(value);
			return Redirect("status");
		}
	}
}
