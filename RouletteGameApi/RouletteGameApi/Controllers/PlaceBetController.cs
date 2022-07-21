using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;
using RouletteGameApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameApi.Controllers
{
    [Route("api/placebet")]
    [ApiController]
    public class PlaceBetController : ControllerBase
    {
        private readonly IPlaceBetRepository _placeBetRepo;

        public PlaceBetController(IPlaceBetRepository placeBetRepo)
        {
            _placeBetRepo = placeBetRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlacedBets()
        {
            var placedbets = await _placeBetRepo.GetPlacedBets();

            if (placedbets is null)
            {
                return NotFound();
            }
            return  Ok(placedbets);
        }

        [HttpPost]
        public async Task Post([FromBody] PlaceBet bet)
        {
            await  _placeBetRepo.PlaceBet(bet);
        }
    }
}
