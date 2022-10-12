using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.DTOs;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProducerInfo = CarsWebApp.Domains.ProducerInfoDomain;
using ProducerCreate = CarsWebApp.Domains.ProducerCreateDomain;

namespace CarsWebApp.Service
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
        public async Task<ProducerInfo> ChangeProducerInfoAsync(int id, ProducerInfo producerInfoDomain)
        {
            var producer = _mapper.Map<Producer>(producerInfoDomain);
            return _mapper.Map<ProducerInfo>(await _producerRepository.ChangeInfoAsync(id, producer));
        }

        public async Task<ProducerCreateResponse> CreateProducerAsync(ProducerCreate producerCreateDomain)
        {
            var producer = _mapper.Map<Producer>(producerCreateDomain);
            return _mapper.Map<ProducerCreateResponse>(await _producerRepository.CreateAsync(producer));
        }

        public async Task<ProducerDomain> DeleteProducerAsync(int id)
        {
            return _mapper.Map<ProducerDomain>(await _producerRepository.DeleteAsync(id));
        }

        public async Task<ProducerDomain> GetProducerByIdAsync(int id)
        {
            return _mapper.Map<ProducerDomain>(await _producerRepository.GetAsync(id));
        }

        public async Task<IEnumerable<ProducerDomain>> GetProducersAsync()
        {
            return _mapper.Map<IEnumerable<ProducerDomain>>(await _producerRepository.GetAll());
        }

        public async Task<ProducerDomain> UpdateProducerAsync(int id, ProducerDomain producerDomain)
        {
            var producer = _mapper.Map<Producer>(producerDomain);
            return _mapper.Map<ProducerDomain>(await _producerRepository.UpdateAsync(id, producer));

        }
    }
}
