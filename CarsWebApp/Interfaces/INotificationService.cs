using System.Threading.Tasks;
using TL;

namespace CarsWebApp.Interfaces
{
    public interface INotificationService
    {
        Task<Message> SendInfoAboutCarAsync(int userId, int carId);
    }
}
