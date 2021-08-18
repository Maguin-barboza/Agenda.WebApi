using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;
using System.Linq;

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
            return Ok(_context.Tbl_Enderecos_Contato);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Endereco endereco = _context.Tbl_Enderecos_Contato.FirstOrDefault(cont => cont.Id == id);
            if(endereco is null)
                return BadRequest("Não existe registro com id especificado.");
            
            return Ok(endereco);
        }

        [HttpPost]
        public IActionResult Post(Endereco endereco)
        {
            _context.Tbl_Enderecos_Contato.Add(endereco);
            
            if(_context.SaveChanges() == 0)
                BadRequest("Não foi possível incluir o registro.");
            
            return Ok(endereco);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Endereco endereco)
        {
            Endereco enderecoAux = _context.Tbl_Enderecos_Contato.FirstOrDefault(cont => cont.Id == Id);
            
            if(enderecoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
             _context.Tbl_Enderecos_Contato.Update(endereco);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar alteração do registro.");
            
            return Ok(endereco);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Endereco enderecoAux = _context.Tbl_Enderecos_Contato.FirstOrDefault(email => email.Id == Id);
            
            if(enderecoAux is null)
                return BadRequest("Não existe registro com id especificado.");
            
            _context.Tbl_Enderecos_Contato.Remove(enderecoAux);

            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível realizar a exclusão do registro");
            
            return Ok($"Endereço do contato foi deletado com sucesso.");
        }
    }
}