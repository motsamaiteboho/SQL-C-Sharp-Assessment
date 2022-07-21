using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayoutController : ControllerBase
    {
        private readonly IPlaceBetRepository _placeBetRepo;
        public PayoutController(IPlaceBetRepository placeBetRepo)
        {
            _placeBetRepo = placeBetRepo;
        }
        // GET: api/<PayoutController>
        [HttpGet]
        public async Task<IActionResult> GetPayoutAsync(int id)
        {
            decimal payamount = 0; 
            var placedbet = await _placeBetRepo.GetPlacedBet(id);
            if (placedbet is null)
            {
                return NotFound();
            }
            if (!placedbet.NumbersOnTheTable.ToString().Contains(PreviouSpinsData.GetPreviousSpins()[PreviouSpinsData.GetPreviousSpins().Count - 1].ToString())){
                return Ok("Lost the bet");
            }
            switch (placedbet.TypeOfBet)
            {
                case TypeOfBet.split:
                  return Ok(placedbet.BetAmount * 17 );
                case TypeOfBet.straightup:
                    return Ok(placedbet.BetAmount * 35);
                case TypeOfBet.street:
                    return Ok(placedbet.BetAmount * 11);
                case TypeOfBet.corner:
                    return Ok(placedbet.BetAmount * 8);
                case TypeOfBet.odd:
                    return Ok(placedbet.BetAmount * 1);
                case TypeOfBet.even:
                    return Ok(placedbet.BetAmount * 1);
                default:
                    break;
            }
            //  straightup, split,street,corner,odd,even
            return Ok(payamount);
        }
    }
}
