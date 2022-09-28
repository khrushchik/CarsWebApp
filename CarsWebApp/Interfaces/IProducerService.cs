using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerDomain>> GetProducers();
        Task<ProducerDomain> GetProducerById(int id);
        Task<ProducerCreateDomain> CreateProducer(ProducerCreateDomain producerCreateDomain);
        Task<ProducerDomain> UpdateProducer(int id, ProducerDomain producerDomain);
        Task<ProducerDomain> DeleteProducer(int id);
        Task<ProducerInfoDomain> ChangeProducerInfo(int id, ProducerInfoDomain producerInfoDomain);

    }
}
