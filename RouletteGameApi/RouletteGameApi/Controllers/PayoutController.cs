using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Entities;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<PayoutController>
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
