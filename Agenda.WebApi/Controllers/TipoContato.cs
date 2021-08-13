using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoContato: ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }
        
        [HttpGet("byId/{id}")]
        public IActionResult Get(int Id)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(TipoContato tipoContato)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int id, TipoContato tipoContato)
        {
            return Ok("");
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            return Ok("");
        }
    }
}