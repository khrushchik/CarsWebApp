using AutoMapper;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Repositories
{
    public class ProducerService : IProducerService
    {
        private readonly IMapper _mapper;
        private readonly ProducerRepository _producerRepository;
        public ProducerService(IMapper mapper, ProducerRepository producerRepository)
        {
            _mapper = mapper;
            _producerRepository = producerRepository;
        }
        public void ChangeProducerInfo(ProducerInfoDTO producerInfoDTO)
        {
            var producer = _mapper.Map<Producer>(producerInfoDTO);
            _mapper.Map<ProducerInfoDTO>(_producerRepository.ChangeInfo(producer));
        }

        public ProducerCreateDTO CreateProducer(ProducerCreateDTO producerCreateDTO)
        {
            var producer = _mapper.Map<Producer>(producerCreateDTO);
            return _mapper.Map<ProducerCreateDTO>(_producerRepository.Create(producer));
        }

        public ProducerDTO DeleteProducer(int id)
        {
            return _mapper.Map<ProducerDTO>(_producerRepository.Delete(id));
        }

        public ProducerDTO GetProducerById(int id)
        {
            return _mapper.Map<ProducerDTO>(_producerRepository.Get(id));
        }

        public IEnumerable<ProducerDTO> GetProducers()
        {
            return _mapper.Map<IEnumerable<ProducerDTO>>(_producerRepository.GetAll());
        }

        public void UpdateProducer(int id, ProducerDTO producerDTO)
        {
            var producer = _mapper.Map<Producer>(producerDTO);
            _mapper.Map<ProducerDTO>(_producerRepository.Update(id, producer));
        }
    }
}
