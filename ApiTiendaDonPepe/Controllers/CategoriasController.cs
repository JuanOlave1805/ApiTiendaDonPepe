using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiendaDonPepe.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repo;
        public CategoriasController(ICategoriaRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Categorias c)
        {
            var id = await _repo.Create(c);
            return CreatedAtAction(nameof(GetById), new { id }, c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Categorias c)
        {
            c.Id = id;
            return await _repo.Update(c) ? Ok(c) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repo.Delete(id) ? NoContent() : NotFound();
        }
    }
}
