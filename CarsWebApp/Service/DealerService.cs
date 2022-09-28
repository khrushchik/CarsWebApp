using AutoMapper;
using CarsWebApp.Domains;
using CarsWebApp.Interfaces;
using CarsWebApp.Models;
using CarsWebApp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<DealerInfoDomain> ChangeDealerInfo(int id, DealerInfoDomain dealerInfoDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerInfoDomain);
            return _mapper.Map<DealerInfoDomain>(await _dealerRepository.ChangeInfo(id, dealer));
        }

        public async Task<DealerCreateDomain> CreateDealer(DealerCreateDomain dealerCreateDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerCreateDomain);
            return _mapper.Map<DealerCreateDomain>(await _dealerRepository.Create(dealer));
        }

        public async Task<DealerDomain> DeleteDealer(int id)
        {
            return _mapper.Map<DealerDomain>(await _dealerRepository.Delete(id));
        }

        public async Task<DealerDomain> GetDealerById(int id)
        {
            return _mapper.Map<DealerDomain>(await _dealerRepository.Get(id));
        }

        public async Task<IEnumerable<DealerDomain>> GetDealers()
        {
            return _mapper.Map<IEnumerable<DealerDomain>>(await _dealerRepository.GetAll());
        }

        public async Task<DealerDomain> UpdateDealer(int id, DealerDomain dealerDomain)
        {
            var dealer = _mapper.Map<Dealer>(dealerDomain);
            return _mapper.Map<DealerDomain>(await _dealerRepository.Update(id, dealer));

        }
    }
}
