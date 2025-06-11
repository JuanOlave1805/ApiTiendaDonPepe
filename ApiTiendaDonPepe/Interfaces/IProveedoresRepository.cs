using ApiTiendaDonPepe.Models;

namespace ApiTiendaDonPepe.Interfaces
{
    public interface IProveedoresRepository
    {
        Task<IEnumerable<Proveedores>> GetAll();
        Task<Proveedores> GetById(int id);
        Task<int> Create(Proveedores proveedor);
        Task<bool> Update(Proveedores proveedor);
        Task<bool> Delete(int id);
    }
}
