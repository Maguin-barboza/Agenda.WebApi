using Agenda.WebApi.Data;
using Agenda.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailContatoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public EmailContatoController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("");
        }

        [HttpGet("byId/id")]
        public IActionResult GetById(int id)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(EmailContato emailContato)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int id, EmailContato emailContato)
        {
            return Ok("");
        }

        [HttpDelete("id")]
        public IActionResult Get(int id)
        {
            return Ok("");
        }
    }
}