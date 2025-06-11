using ApiTiendaDonPepe.Models;

namespace ApiTiendaDonPepe.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<IEnumerable<Usuarios>> GetAll();
        Task<Usuarios> GetById(int id);
        Task<int> Create(Usuarios usuario);
        Task<bool> Update(Usuarios usuario);
        Task<bool> Delete(int id);
    }
}
