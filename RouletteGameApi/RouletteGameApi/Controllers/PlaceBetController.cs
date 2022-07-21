using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;
using RouletteGameApi.Dto;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlacedBet(int id)
        {
            try
            {
                var placedbet  = await  _placeBetRepo.GetPlacedBet(id);
                if (placedbet == null)
                    return NotFound();

                return Ok(placedbet);
            }   
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBet([FromBody] PlaceBetDto bet)
        {
            var placedBet =  await _placeBetRepo.PlaceBet(bet);

            return CreatedAtAction(nameof(PlaceBet), new { id = placedBet.Id }, placedBet);
           // await  _placeBetRepo.PlaceBet(bet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet( int id, [FromBody] UpdateBetDto bet)
        {
            var dbPlacedBet = await _placeBetRepo.GetPlacedBet(id);
            if(dbPlacedBet is null)
            {
                return NotFound();
            }

            await _placeBetRepo.UpdateBet(id, bet);
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            var dbPlacedBet = await _placeBetRepo.GetPlacedBet(id);
            if (dbPlacedBet is null)
            {
                return NotFound();
            }

            await _placeBetRepo.DeleteBet(id);
            return NoContent();
        }

    }
}
