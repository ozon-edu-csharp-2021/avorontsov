using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
        private readonly List<MerchandiseItem> MerchandiseItems = new List<MerchandiseItem>
        {
            new MerchandiseItem(1, "Футболка", 10),
            new MerchandiseItem(2, "Толстовка", 20),
            new MerchandiseItem(3, "Кепка", 15)
        };

        public Task<List<MerchandiseItem>> GetAll(CancellationToken _) => Task.FromResult(MerchandiseItems);

        public Task<MerchandiseItem> GetById(long itemId, CancellationToken _)
        {
            var MerchandiseItem = MerchandiseItems.FirstOrDefault(x => x.ItemId == itemId);
            return Task.FromResult(MerchandiseItem);
        }

        public Task<MerchandiseItem> Add(MerchandiseItemCreationModel MerchandiseItem, CancellationToken _)
        {
            var itemId = MerchandiseItems.Max(x => x.ItemId) + 1;
            var newMerchandiseItem = new MerchandiseItem(itemId, MerchandiseItem.ItemName, MerchandiseItem.Quantity);
            MerchandiseItems.Add(newMerchandiseItem);
            return Task.FromResult(newMerchandiseItem);
        }
    }
}