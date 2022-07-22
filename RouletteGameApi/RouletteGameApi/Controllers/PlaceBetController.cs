using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Dto;
using RouletteGameApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameApi.Controllers
{
    [Route("api/placebet")]
    [ApiController]
    public class PlaceBetController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private ILogger<PlaceBetController> _logger; 
        public PlaceBetController(IRepositoryWrapper repository, ILogger<PlaceBetController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlacedBets()
        {
            _logger.LogInformation("Fetching all the placedbets from the storage");
            var placedbets = await _repository.PlaceBet.GetPlacedBets();

            _logger.LogInformation($"Returning  {placedbets.Count()}  placed bets");
            if(placedbets.Any())
                return  Ok(placedbets);

            return NotFound(); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlacedBet(int id)
        {
             _logger.LogInformation("Fetching a placedbet from the storage");
             var placedbet  = await _repository.PlaceBet.GetPlacedBet(id);
            if (placedbet is null)
            {
                return NotFound();
            }
            return Ok(placedbet);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBet([FromBody] PlaceBetDto bet)
        {
            _logger.LogInformation("Placing a bet");
            var placedBet =  await _repository.PlaceBet.PlaceBet(bet);

            _logger.LogInformation(" A bet was successfully placed");
            return CreatedAtAction(nameof(PlaceBet), new { id = placedBet.Id }, placedBet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBet( int id, [FromBody] UpdateBetDto bet)
        {
            _logger.LogInformation("updating a placed bet");
            var dbPlacedBet = await _repository.PlaceBet.GetPlacedBet(id);

            if (dbPlacedBet is null)
            {
                return NotFound();
            }
            await _repository.PlaceBet.UpdateBet(id, bet);
            _logger.LogInformation("a bet was uptdated sucessfully");
           
            return NoContent(); 
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBet(int id)
        {
            _logger.LogInformation("Deleting a placed bet");
            var dbPlacedBet = await _repository.PlaceBet.GetPlacedBet(id);
            if(dbPlacedBet is null)
            {
                return NotFound();
            }
            await _repository.PlaceBet.DeleteBet(id);
            _logger.LogInformation("bet was successfully deleted");
            return NoContent();
        }

    }
}
