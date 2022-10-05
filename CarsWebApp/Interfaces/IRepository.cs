using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T item);
        Task<T> UpdateAsync(int id, T item);
        Task<T> DeleteAsync(int id);
        Task<T> ChangeInfoAsync(int id, T item);


    }
}
