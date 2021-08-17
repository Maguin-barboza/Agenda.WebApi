using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Agenda.WebApi.Model.Models_Endereco;
using Agenda.WebApi.Data;


namespace Agenda.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BairroController: ControllerBase
    {
        private readonly AgendaContext _context;

        public BairroController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tbl_Bairros);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            Bairro bairro = _context.Tbl_Bairros.FirstOrDefault(bai => bai.Id == id);

            if(bairro is null)
                return BadRequest("Não foi encontrado nenhum registro com id especificado.");
            
            return Ok(bairro);
        }

        [HttpGet("byDescricao")]
        public IActionResult GetByName(string descricao)
        {
            Bairro bairro = _context.Tbl_Bairros.FirstOrDefault(bai => bai.Descricao.Contains(descricao));
            
            if(bairro is null)
                return BadRequest("Não foi encontrado nenhum registro com a descrição especificada.");
            
            return Ok(bairro);
        }

        [HttpPost]
        public IActionResult Post(Bairro bairro)
        {
            _context.Tbl_Bairros.Add(bairro);
            
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível adicionar bairro.");

            return Ok(bairro);
        }

        [HttpPut("id")]
        public IActionResult Put(int Id, Bairro bairro)
        {
            Bairro bairroAux = _context.Tbl_Bairros.FirstOrDefault(bai => bai.Id == Id);
            
            if(bairroAux is null)
                return BadRequest("Não foi possível encontrar o bairro com id especificado.");

            
            _context.Tbl_Bairros.Update(bairro);
            if(_context.SaveChanges() ==0)
                return BadRequest("Não foi possível alterar bairro.");
            
            return Ok(bairro);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            Bairro bairroAux = _context.Tbl_Bairros.FirstOrDefault(bai => bai.Id == Id);

            if(bairroAux is null)
                return BadRequest("Não foi possível encontrar o bairro com id especificado.");

            _context.Tbl_Bairros.Remove(bairroAux);
            if(_context.SaveChanges() == 0)
                return BadRequest("Não foi possível deletar o bairro.");
            
            return Ok($"Bairro {bairroAux.Descricao} deletado com sucesso.");

        }
    }
}