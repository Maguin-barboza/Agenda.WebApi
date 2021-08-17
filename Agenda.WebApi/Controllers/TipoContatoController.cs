using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model;
using Agenda.WebApi.Data;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoContatoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public TipoContatoController(AgendaContext context)
        {
            _context = context;
        }
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