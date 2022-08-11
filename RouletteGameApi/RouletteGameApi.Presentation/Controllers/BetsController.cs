using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Presentation.ActionFilters;
using RouletteGameApi.Presentation.ModelBinders;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RouletteGameApi.Presentation.Controllers
{
    [Route("api/bets")]
    [ApiController]
    public class BetsController : ControllerBase
    {
		private readonly IServiceManager _service;

		public BetsController(IServiceManager service) => _service = service;

		[HttpGet]
		public async Task<IActionResult> GetBets([FromQuery] BetParameters betParameters)
		{
				var pagedResult = await _service.BetService.GetAllBetsAsync(betParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.MetaData));

				return Ok(pagedResult.bets);
		}

		[HttpGet("{id:guid}", Name = "BetById")]
		public async Task<IActionResult> GetBet(Guid id) 
		{ 
			var bet = await _service.BetService.GetBetAsync(id, trackChanges: false); 
			
			return Ok(bet); 
		}
        [HttpGet("collection/({ids})", Name = "betCollection")]
        public async Task<IActionResult> GetBetCollection
        ([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var bets = await _service.BetService.GetByIdsAsync(ids, trackChanges: false);

            return Ok(bets);
        }

        [HttpPost(Name = "CreateBet")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateBet([FromBody] BetForCreationDto bet)
        {
            var createdBet= await _service.BetService.PlaceBetForNextSpinAsync(bet,trackChanges:true);

            return CreatedAtRoute("BetById", new { id = createdBet.Id }, createdBet);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateBetCollection
         ([FromBody] IEnumerable<BetForCreationDto> betCollection)
        {
            var result = await _service.BetService.CreateBetCollectionAsync(betCollection);

            return CreatedAtRoute("BetCollection", new { result.ids }, result.bets);
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateBet(Guid id, [FromBody] BetForUpdateDto bet)
        {
            await _service.BetService.UpdateBetAsync(id, bet, trackChanges: true);

            return NoContent();
        }
    }

}
