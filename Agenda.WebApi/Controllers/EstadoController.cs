using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public EstadoController(AgendaContext context)
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

        [HttpGet("byName")]
        public IActionResult GetByName(string nome)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(Estado estado)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Estado estado)
        {
            return Ok("");
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok("");
        }
    }
}