using MerchandiseService.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services.Interfaces
{
    public interface IMerchandiseService
    {
        Task<List<MerchandiseItem>> GetAll(CancellationToken token);

        Task<MerchandiseItem> GetById(long itemId, CancellationToken _);

        Task<MerchandiseItem> Add(MerchandiseItemCreationModel merchandiseItem, CancellationToken _);

        Task<MerchandiseItem> GetMerch();

        Task<MerchandiseItem> GetMerchExtraditionInfo();
    }
}