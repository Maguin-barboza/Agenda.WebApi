using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public EnderecoController(AgendaContext context)
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
        public IActionResult Post(Endereco endereco)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int id, Endereco endereco)
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