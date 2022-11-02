using System.Threading.Tasks;
using TL;
using CarsWebApp.Interfaces;

namespace CarsWebApp.Service
{
    public class NotificationService: INotificationService
    {
        TelegramApiService _telegramApiService;
        ICarService _carService;
        IUserService _userService;
        public NotificationService(TelegramApiService telegramApiService, ICarService carService, IUserService userService)
        {
            _telegramApiService = telegramApiService;
            _carService = carService;
            _userService = userService;
        }

        public async Task<Message> SendInfoAboutCarAsync(int userId, int carId)
        {
            var helloMessage = string.Empty;
            var carInfo = await _carService.GetCarInfo(carId);
            var userEntity = await _userService.GetUserByIdAsync(userId);

            helloMessage += carInfo.Info;

            return await _telegramApiService.SendMessageByUsernameAsync(helloMessage, userEntity.UserName);
        }
    }
}
