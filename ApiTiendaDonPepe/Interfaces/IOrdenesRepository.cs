using ApiTiendaDonPepe.Models;

namespace ApiTiendaDonPepe.Interfaces
{
    public interface IOrdenesRepository
    {
        Task<IEnumerable<Ordenes>> GetAll();
        Task<Ordenes> GetById(int id);
        Task<int> Create(Ordenes orden);
        Task<bool> Update(Ordenes orden);
        Task<bool> Delete(int id);
    }
}
