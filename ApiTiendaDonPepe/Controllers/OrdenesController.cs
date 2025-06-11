using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTiendaDonPepe.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesController : ControllerBase
    {
        private readonly IOrdenesRepository _repo;
        public OrdenesController(IOrdenesRepository repo) => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _repo.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Ordenes o)
        {
            var id = await _repo.Create(o);
            return CreatedAtAction(nameof(GetById), new { id }, o);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Ordenes o)
        {
            o.Id = id;
            return await _repo.Update(o) ? Ok(o) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _repo.Delete(id) ? NoContent() : NotFound();
        }
    }
}
