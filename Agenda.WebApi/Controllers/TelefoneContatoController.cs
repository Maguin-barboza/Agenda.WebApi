using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Agenda.WebApi.Data;
using Agenda.WebApi.Model;

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
            return Ok(_context.Tbl_Telefones_Contato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Telefone telefone = _context.Tbl_Telefones_Contato.FirstOrDefault(tel => tel.Id == id);
            if(telefone is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(telefone);
        }

        [HttpPost]
        public IActionResult Post(Telefone telefone)
        {
            _context.Tbl_Telefones_Contato.Add(telefone);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(telefone);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, Telefone telefone)
        {
            Telefone telefoneAux = _context.Tbl_Telefones_Contato.AsNoTracking().FirstOrDefault(tel => tel.Id == Id);
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Telefones_Contato.Update(telefone);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(telefone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Telefone telefoneAux = _context.Tbl_Telefones_Contato.FirstOrDefault(tel => tel.Id == Id);
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Telefones_Contato.Remove(telefoneAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Telefone foi deletado com sucesso.");
        }
    }
}