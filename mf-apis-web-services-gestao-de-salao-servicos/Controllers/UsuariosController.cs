using mf_apis_web_services_gestao_de_salao_servicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_gestao_de_salao_servicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Usuarios.ToListAsync();
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UsuarioDto model)
        {
            Usuario novo = new Usuario()
            {
                Nome = model.Nome,
                Email = model.Email,
                Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha),
                Telefone = model.Telefone,
                Endereco = model.Endereco,
                Cidade = model.Cidade,
                Estado = model.Estado,
                Cep = model.Cep,
                DataNascimento = model.DataNascimento,
                Genero = model.Genero,
                Perfil = model.Perfil
            };

            _context.Usuarios.Add(novo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = novo.Id }, novo);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Usuarios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (model == null) return NotFound();

            return Ok(model);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UsuarioDto model)
        {
            if (id != model.Id) return BadRequest();
            var modeloDb = await _context.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (modeloDb == null) return NotFound();

            modeloDb.Nome= model.Nome;
            modeloDb.Senha = BCrypt.Net.BCrypt.HashPassword(model.Senha);
            modeloDb.Perfil = model.Perfil;

            _context.Usuarios.Update(modeloDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Usuarios.FindAsync(id);
            if (model == null) return NotFound();
            _context.Usuarios.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
