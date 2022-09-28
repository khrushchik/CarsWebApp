using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T item);
        Task Update(int id, T item);
        Task<T> Delete(int id);
        Task ChangeInfo(T item);


    }
}
