using Agenda.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController: ControllerBase
    {
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
        public IActionResult GetByName(string nome, string sobrenome)
        {
            return Ok("");
        }

        [HttpPost]
        public IActionResult Post(Contato contato)
        {
            return Ok("");
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Contato contato)
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