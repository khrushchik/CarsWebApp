using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
//using ProducerEntity = CarsWebApp.Models.Producer;
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
        public async Task<ProducerInfoDomain> ChangeProducerInfo(int id, ProducerInfoDomain producerInfoDomain)
        {
            var producer = _mapper.Map<Producer>(producerInfoDomain);
            return _mapper.Map<ProducerInfoDomain>(await _producerRepository.ChangeInfo(id, producer));
        }

        public async Task<ProducerCreateDomain> CreateProducer(ProducerCreateDomain producerCreateDomain)
        {
            var producer = _mapper.Map<Producer>(producerCreateDomain);
            return _mapper.Map<ProducerCreateDomain>(await _producerRepository.Create(producer));
        }

        public async Task<ProducerDomain> DeleteProducer(int id)
        {
            return _mapper.Map<ProducerDomain>(await _producerRepository.Delete(id));
        }

        public async Task<ProducerDomain> GetProducerById(int id)
        {
            return _mapper.Map<ProducerDomain>(await _producerRepository.Get(id));
        }

        public async Task<IEnumerable<ProducerDomain>> GetProducers()
        {
            return _mapper.Map<IEnumerable<ProducerDomain>>(await _producerRepository.GetAll());
        }

        public async Task<ProducerDomain> UpdateProducer(int id, ProducerDomain producerDomain)
        {
            var producer = _mapper.Map<Producer>(producerDomain);
            return _mapper.Map<ProducerDomain>(await _producerRepository.Update(id, producer));
            
        }
    }
}
