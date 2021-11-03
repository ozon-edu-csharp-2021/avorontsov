using MerchandiseService.HttpModels;
using MerchandiseService.Models;
using MerchandiseService.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService MerchandiseService)
        {
            _merchandiseService = MerchandiseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MerchandiseItem>>> GetAll(CancellationToken ct)
        {
            var merchandiseItems = await _merchandiseService.GetAll(ct);
            return Ok(merchandiseItems);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(typeof(MerchandiseItem), StatusCodes.Status200OK)]
        public async Task<ActionResult<MerchandiseItem>> GetById(long id, CancellationToken ct)
        {
            var merchandiseItem = await _merchandiseService.GetById(id, ct);
            if (merchandiseItem is null)
            {
                return NotFound();
            }

            return merchandiseItem;
        }

        /// <summary>
        /// Добавляет Merchandise item.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<MerchandiseItem>> Add(MerchandiseItemPostViewModel postViewModel, CancellationToken ct)
        {
            var createdMerchandiseItem = await _merchandiseService.Add(new MerchandiseItemCreationModel
            {
                ItemName = postViewModel.ItemName,
                Quantity = postViewModel.Quantity
            }, ct);
            return Ok(createdMerchandiseItem);
        }

        /// <summary>
        /// Запросить мерч
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PostMerch")]
        public async Task<IActionResult> PostMerch()
        {
            var merchandiseItems = await _merchandiseService.PostMerch();
            return Ok(merchandiseItems);
        }

        /// <summary>
        /// Получить информацию о выдаче мерча
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMerchExtraditionInfo")]
        public async Task<IActionResult> GetMerchExtraditionInfo(MerchandiseGetItem item = default)
        {
            if (item == default)
            {
                var merchandiseItems = await _merchandiseService.GetMerchExtraditionInfo();
                return Ok(merchandiseItems);
            }
            else
                return BadRequest();
        }
    }

    public class CustomException : Exception
    {
        public CustomException() : base("some custom exception")
        {
        }
    }
}