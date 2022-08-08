using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.Presentation.Controllers
{
    [Route("api/spins/{spinId}/bets")]
    [ApiController]
    public class BetsController : ControllerBase
    {
		private readonly IServiceManager _service;

		public BetsController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetBets(Guid spinId)
		{
				var bets = _service.BetService.GetAllBets(spinId,trackChanges: false);

				return Ok(bets);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetBet(Guid id, Guid spinId) 
		{ 
			var bet = _service.BetService.GetBet(id,spinId, trackChanges: false); 
			
			return Ok(bet); 
		}
	}

}
