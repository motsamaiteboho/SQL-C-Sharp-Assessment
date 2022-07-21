using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RouletteGameApi.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RouletteGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowPreviousSpinsController : ControllerBase
    {
        // GET: api/<ShowPreviousSpinsController>
        [HttpGet]
        public string GetPreviousSpins()
        {
            return "Previous Winning Numbers: " + JsonConvert.SerializeObject(PreviouSpinsData.GetPreviousSpins());
        }
    }
}
