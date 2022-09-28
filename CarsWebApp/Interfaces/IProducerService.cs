using CarsWebApp.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IProducerService
    {
        IEnumerable<ProducerDTO> GetProducers();
        ProducerDTO GetProducerById(int id);
        ProducerCreateDTO CreateProducer(ProducerCreateDTO producerCreateDTO);
        void UpdateProducer(int id, ProducerDTO producerDTO);
        ProducerDTO DeleteProducer(int id);
        void ChangeProducerInfo(ProducerInfoDTO producerInfoDTO);

    }
}
