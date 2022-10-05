using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using DealerInfo = CarsWebApp.Domains.DealerInfoDomain;
using DealerCreate = CarsWebApp.Domains.DealerCreateDomain;

namespace CarsWebApp.Service
{
    public class DealerService : IDealerService
    {
        private readonly IMapper _mapper;
        private readonly DealerRepository _dealerRepository;
        public DealerService(IMapper mapper, DealerRepository dealerRepository)
        {
            _mapper = mapper;
            _dealerRepository = dealerRepository;
        }
        public async Task<DealerInfo> ChangeDealerInfoAsync(int id, DealerInfo dealerInfoDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerInfoDomain);
            return _mapper.Map<DealerInfo>(await _dealerRepository.ChangeInfoAsync(id, dealer));
        }

        public async Task<DealerCreate> CreateDealerAsync(DealerCreate dealerCreateDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerCreateDomain);
            return _mapper.Map<DealerCreate>(await _dealerRepository.CreateAsync(dealer));
        }

        public async Task<DealerDomain> DeleteDealerAsync(int id)
        {
            return _mapper.Map<DealerDomain>(await _dealerRepository.DeleteAsync(id));
        }

        public async Task<DealerDomain> GetDealerByIdAsync(int id)
        {
            return _mapper.Map<DealerDomain>(await _dealerRepository.GetAsync(id));
        }

        public async Task<IEnumerable<DealerDomain>> GetDealersAsync()
        {
            return _mapper.Map<IEnumerable<DealerDomain>>(await _dealerRepository.GetAll());
        }

        public async Task<DealerDomain> UpdateDealerAsync(int id, DealerDomain dealerDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerDomain);
            return _mapper.Map<DealerDomain>(await _dealerRepository.UpdateAsync(id, dealer));

        }
    }
}
