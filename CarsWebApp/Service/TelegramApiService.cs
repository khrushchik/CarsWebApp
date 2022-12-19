using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using TL;

namespace CarsWebApp.Service
{
    public class TelegramApiService : BackgroundService
    {
		public readonly WTelegram.Client Client;
		public User User => Client.User;
		public string ConfigNeeded = "connecting";

		private readonly IConfiguration _config;

		public TelegramApiService(IConfiguration config)
		{
			_config = config;
			Client = new WTelegram.Client(what => _config[what]);
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			ConfigNeeded = await DoLogin(_config["phone_number"]);
		}

		public async Task<string> DoLogin(string loginInfo)
		{
			return ConfigNeeded = await Client.Login(loginInfo);
		}

		public async Task<Message> SendMessageByUsernameAsync(string message, string username)
		{
			var resolved = await Client.Contacts_ResolveUsername(username);

			var entities = Client.HtmlToEntities(ref message);

			return await Client.SendMessageAsync(resolved, message, entities: entities);
		}

		public async Task<Message> SendMessageByPhoneNumberAsync(string message, string phone)
		{
			var resolved = await Client.Contacts_ResolvePhone(phone);

			return await Client.SendMessageAsync(resolved, message);
		}

	}
}
