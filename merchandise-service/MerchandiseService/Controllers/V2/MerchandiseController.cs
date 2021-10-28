using MerchandiseService.HttpModels;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Controllers.V2
{
    [ApiController]
    [Route("v2/api/merchandises")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        [HttpPost]
        public async Task<ActionResult<MerchandiseItem>> Add(MerchandiseItemPostViewModelV2 postViewModel, CancellationToken token)
        {
            var createdMerchandiseItem = await _merchandiseService.Add(new MerchandiseItemCreationModel
            {
                ItemName = postViewModel.ItemName,
                Quantity = postViewModel.Quantity.Value
            }, token);
            return Ok(createdMerchandiseItem);
        }
    }
}