using CarsWebApp.Domains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsWebApp.Interfaces
{
    public interface IDealerService
    {
        Task<IEnumerable<DealerDomain>> GetDealersAsync();
        Task<DealerDomain> GetDealerByIdAsync(int id);
        Task<DealerCreateDomain> CreateDealerAsync(DealerCreateDomain dealerCreateDomain);
        Task<DealerDomain> UpdateDealerAsync(int id, DealerDomain dealerDomain);
        Task<DealerDomain> DeleteDealerAsync(int id);
        Task<DealerInfoDomain> ChangeDealerInfoAsync(int id, DealerInfoDomain dealerInfoDomain);
    }
}
