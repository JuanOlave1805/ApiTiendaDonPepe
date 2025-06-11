using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiendaDonPepe.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _repo;
        public UsuariosController(IUsuariosRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuarios p)
        {
            var id = await _repo.Create(p);
            return CreatedAtAction(nameof(GetById), new { id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuarios u)
        {
            u.Id = id;
            return await _repo.Update(u) ? Ok(u) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repo.Delete(id) ? NoContent() : NotFound();
        }
    }
}
