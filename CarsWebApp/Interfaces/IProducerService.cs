using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerDomain>> GetProducersAsync();
        Task<ProducerDomain> GetProducerByIdAsync(int id);
        Task<ProducerCreateDomain> CreateProducerAsync(ProducerCreateDomain producerCreateDomain);
        Task<ProducerDomain> UpdateProducerAsync(int id, ProducerDomain producerDomain);
        Task<ProducerDomain> DeleteProducerAsync(int id);
        Task<ProducerInfoDomain> ChangeProducerInfoAsync(int id, ProducerInfoDomain producerInfoDomain);

    }
}
