using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;
using System.Linq;

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
            return Ok(_context.Tbl_Estados);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Estado estado = _context.Tbl_Estados.FirstOrDefault(estado => estado.Id == id);
            if(estado is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(estado);
        }

        [HttpPost]
        public IActionResult Post(Estado estado)
        {
            _context.Tbl_Estados.Add(estado);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(estado);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Estado estado)
        {
            Estado estadoAux = _context.Tbl_Estados.FirstOrDefault(estado => estado.Id == Id);
            
            if(estadoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Estados.Update(estado);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(estado);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Estado estadoAux = _context.Tbl_Estados.FirstOrDefault(estado => estado.Id == Id);
            
            if(estadoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Estados.Remove(estadoAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Estado foi deletado com sucesso.");
        }
    }
}