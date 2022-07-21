using Microsoft.AspNetCore.Mvc;
using RouletteGameApi.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameApi.Controllers
{
    [Route("api/spin")]
    [ApiController]
    public class SpinController : ControllerBase
    {
        // GET: api/<SpinController>
        [HttpGet]
        public int  Get()
        {
            var spin = (int)Random.Shared.Next(0, 37);
            PreviouSpinsData.add(spin);
            return spin;
        } 
    }
}
