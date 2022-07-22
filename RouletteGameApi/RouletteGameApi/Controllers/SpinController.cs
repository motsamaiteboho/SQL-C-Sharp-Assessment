using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouletteGameApi.Contracts;
using RouletteGameApi.Database;
using RouletteGameApi.Entities;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<SpinController>
        [HttpGet]
        public async Task<Spin> Get()
        {
            var winningnumber = (int)Random.Shared.Next(0, 37);
            var spin = new Spin()
            {
                Id = Guid.NewGuid(),
                WinningNumber = winningnumber,
            };
            return await repository.spin.SpinWheel(spin);
        } 
        [HttpGet]
        [Route("/showpreviosspins")]
        public async Task<IEnumerable<Spin>> GetPreviousSpins()
        {
            return await repository.spin.GetPreviousSpins();
        }
    }
}
