using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Contracts;

namespace RouletteGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayoutController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public PayoutController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPayout(int id)
        {
            var payout = await _repository.Payout.GetPayout(id);
            if (payout is null)
            {
                return NotFound();
            }
           return Ok(payout);
        }
    }
}
