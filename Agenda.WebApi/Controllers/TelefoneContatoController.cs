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
		private readonly IRepository _repository;

		public TelefoneContatoController(IRepository repository, AgendaContext context)
        {
            _context = context;
            _repository = repository;
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
            _repository.Add(telefone);
            
            if(_repository.SaveChanges())
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(telefone);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int Id, Telefone telefone)
        {
            Telefone telefoneAux = _context.Tbl_Telefones_Contato.AsNoTracking().FirstOrDefault(tel => tel.Id == Id);
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Update(telefone);
            
            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(telefone);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            Telefone telefoneAux = _context.Tbl_Telefones_Contato.FirstOrDefault(tel => tel.Id == Id);
            
            if(telefoneAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _repository.Delete(telefoneAux);

            if(_repository.SaveChanges())
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Telefone foi deletado com sucesso.");
        }
    }
}