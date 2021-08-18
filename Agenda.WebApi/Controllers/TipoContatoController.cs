using System.Linq;

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
            return Ok(_context.Tbl_Tipos_Contato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            TipoContato tipoContato = _context.Tbl_Tipos_Contato.FirstOrDefault(cont => cont.Id == id);
            
            if(tipoContato is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(tipoContato);
        }

        [HttpPost]
        public IActionResult Post(TipoContato tipoContato)
        {
            _context.Tbl_Tipos_Contato.Add(tipoContato);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(tipoContato);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, TipoContato tipoContato)
        {
            TipoContato tipoContatoAux = _context.Tbl_Tipos_Contato.FirstOrDefault(cont => cont.Id == Id);
            
            if(tipoContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Tipos_Contato.Update(tipoContato);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(tipoContato);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            TipoContato tipoContatoAux = _context.Tbl_Tipos_Contato.FirstOrDefault(email => email.Id == Id);
            
            if(tipoContatoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Tipos_Contato.Remove(tipoContatoAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Tipo Contato foi deletado com sucesso.");
        }
    }
}