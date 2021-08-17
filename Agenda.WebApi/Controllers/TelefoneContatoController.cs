using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelefoneContatoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public TelefoneContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(Telefone telefone)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int id, Telefone telefone)
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