using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGameApi.Presentation.Controllers
{
	[Route("api/spins")]
	[ApiController]
	public class SpinsController : ControllerBase
	{
		private readonly IServiceManager _service;

		public SpinsController(IServiceManager service) => _service = service;

		[HttpGet]
		public IActionResult GetSpins()
		{
			var spins = _service.SpinService.GetAllSpins(trackChanges: false);

			return Ok(spins);
		}

		[HttpGet("{id:Guid}")]
		public IActionResult GetSpin(Guid id)
		{
			var spins = _service.SpinService.GetSpin(id, trackChanges: false);

			return Ok(spins);
		}
	}
	
}
