using ApiTiendaDonPepe.Models;

namespace ApiTiendaDonPepe.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Productos>> GetAll();
        Task<Productos> GetById(int id);
        Task<int> Create(Productos producto);
        Task<bool> Update(Productos producto);
        Task<bool> Delete(int id);
    }
}
