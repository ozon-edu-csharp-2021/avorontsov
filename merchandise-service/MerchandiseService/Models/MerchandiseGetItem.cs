namespace MerchandiseService.Models
{
    public class MerchandiseGetItem
    {
        public MerchandiseGetItem(long itemId)
        {
            ItemId = itemId;
        }

        public long ItemId { get; }
    }
}