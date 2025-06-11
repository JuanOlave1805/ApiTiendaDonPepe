using ApiTiendaDonPepe.Models;

namespace ApiTiendaDonPepe.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categorias>> GetAll();
        Task<Categorias> GetById(int id);
        Task<int> Create(Categorias categoria);
        Task<bool> Update(Categorias categoria);
        Task<bool> Delete(int id);
    }
}
