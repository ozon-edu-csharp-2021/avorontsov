using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/Merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService MerchandiseService)
        {
            _merchandiseService = MerchandiseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var MerchandiseItems = await _merchandiseService.GetAll(token);
            return Ok(MerchandiseItems);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<MerchandiseItem>> GetById(long id, CancellationToken token)
        {
            var MerchandiseItem = await _merchandiseService.GetById(id, token);
            if (MerchandiseItem is null)
            {
                return NotFound();
            }

            return MerchandiseItem;
        }

        /// <summary>
        /// Добавляет Merchandise item.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchandiseItem>> Add(MerchandiseItemPostViewModel postViewModel, CancellationToken token)
        {
            var createdMerchandiseItem = await _merchandiseService.Add(new MerchandiseItemCreationModel
            {
                ItemName = postViewModel.ItemName,
                Quantity = postViewModel.Quantity
            }, token);
            return Ok(createdMerchandiseItem);
        }
    }

    public class CustomException : Exception
    {
        public CustomException() : base("some custom exception")
        {
        }
    }
}