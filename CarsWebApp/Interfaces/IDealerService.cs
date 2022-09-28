using CarsWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IDealerService
    {
        Task<IEnumerable<DealerDomain>> GetDealers();
        Task<DealerDomain> GetDealerById(int id);
        Task<DealerCreateDomain> CreateDealer(DealerCreateDomain dealerCreateDomain);
        Task<DealerDomain> UpdateDealer(int id, DealerDomain dealerDomain);
        Task<DealerDomain> DeleteDealer(int id);
        Task<DealerInfoDomain> ChangeDealerInfo(int id, DealerInfoDomain dealerInfoDomain);
    }
}
