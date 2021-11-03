using System;

namespace MerchandiseService.HttpModels
{
    public class MerchandiseItemPostViewModelV2
    {
        public string ItemName { get; set; }
        
        public AvailableQuantity Quantity { get; set; }
    }
}