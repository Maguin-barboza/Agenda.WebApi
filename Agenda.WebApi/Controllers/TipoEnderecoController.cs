using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoEnderecoController: ControllerBase
    {
        private readonly AgendaContext _context;

        public TipoEnderecoController(AgendaContext context)
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
        public IActionResult Post(TipoEndereco tipoEndereco)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int id, TipoEndereco tipoEndereco)
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