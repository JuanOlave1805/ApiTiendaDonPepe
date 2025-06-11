using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Dapper;
using Npgsql;

namespace ApiTiendaDonPepe.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConfiguration _config;
        public UsuariosRepository(IConfiguration config) => _config = config;

        private NpgsqlConnection GetConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Usuarios>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Usuarios>("SELECT * FROM public.\"Usuarios\"");
        }

        public async Task<Usuarios> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Usuarios>(
                "SELECT * FROM public.\"Usuarios\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public async Task<int> Create(Usuarios o)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO public.""Usuarios"" (""Nombres"", ""Apellidos"", ""Correo"", ""Usuario"", ""Clave"") 
                VALUES (@Nombres, @Apellidos, @Correo, @Usuario, @Clave);";
            return await conn.ExecuteAsync(sql, o);
        }

        public async Task<bool> Update(Usuarios o)
        {
            using var conn = GetConnection();
            var sql = @"UPDATE public.""Ordenes"" 
                SET ""Usuario_id"" = @Usuario_id,
                    ""Producto_id"" = @Producto_id,
                    ""Cantidad"" = @Cantidad,
                    ""Tipo"" = @Tipo,
                    ""Fecha"" = @Fecha
                WHERE ""Id"" = @Id";
            return await conn.ExecuteAsync(sql, o) > 0;
        }


        public async Task<bool> Delete(int id)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(
                "DELETE FROM public.\"Usuarios\" WHERE \"Id\" = @Id", new { Id = id }
            ) > 0;
        }
    }
}
