using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Dapper;
using Npgsql;

namespace ApiTiendaDonPepe.Repositories
{
    public class ProveedoresRepository : IProveedoresRepository
    {
        private readonly IConfiguration _config;
        public ProveedoresRepository(IConfiguration config) => _config = config;

        private NpgsqlConnection GetConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Proveedores>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Proveedores>("SELECT * FROM public.\"Proveedores\"");
        }

        public async Task<Proveedores> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Proveedores>(
                "SELECT * FROM public.\"Proveedores\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public async Task<int> Create(Proveedores p)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO public.""Proveedores"" (""Nombre"", ""Nit"") 
            VALUES (@Nombre, @Nit);";
            return await conn.ExecuteAsync(sql, p);
        }

        public async Task<bool> Update(Proveedores p)
        {
            using var conn = GetConnection();
            var sql = @"UPDATE public.""Proveedores"" 
            SET ""Nombre"" = @Nombre,
                ""Nit"" = @Nit
            WHERE ""Id"" = @Id";
            return await conn.ExecuteAsync(sql, p) > 0;
        }


        public async Task<bool> Delete(int id)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(
                "DELETE FROM public.\"Proveedores\" WHERE \"Id\" = @Id", new { Id = id }
            ) > 0;
        }
    }

}
