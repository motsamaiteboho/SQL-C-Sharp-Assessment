using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;

namespace RouletteGameApi.Controllers
{
    [Route("api/spin")]
    [ApiController]
    public class SpinController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;

        public SpinController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var winningnumber = (int)Random.Shared.Next(0, 37);
            var spin = new Spin()
            {
                Id = Guid.NewGuid(),
                WinningNumber = winningnumber,
            };
            var spinResult = await repository.spin.SpinWheel(spin);
            if (spinResult == null)
            {
                return NotFound();
            }
            return  Ok(spinResult);
        } 
        [HttpGet]
        [Route("/showpreviosspins")]
        public async Task<IActionResult> GetPreviousSpins()
        {
            var spins = await repository.spin.GetPreviousSpins();
            if (spins == null)
            {
                return NotFound();
            }
            return Ok(spins);
        }
    }
}
