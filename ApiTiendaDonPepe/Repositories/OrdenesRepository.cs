using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Dapper;
using Npgsql;

namespace ApiTiendaDonPepe.Repositories
{
    public class OrdenesRepository : IOrdenesRepository
    {
        private readonly IConfiguration _config;
        public OrdenesRepository(IConfiguration config) => _config = config;

        private NpgsqlConnection GetConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Ordenes>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Ordenes>("SELECT * FROM public.\"Ordenes\"");
        }

        public async Task<Ordenes> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Ordenes>(
                "SELECT * FROM public.\"Ordenes\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public async Task<int> Create(Ordenes o)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO public.""Ordenes"" (""Usuario_id"", ""Producto_id"", ""Cantidad"", ""Tipo"", ""Fecha"") 
                VALUES (@Usuario_id, @Producto_id, @Cantidad, @Tipo, @Fecha);";
            return await conn.ExecuteAsync(sql, o);
        }

        public async Task<bool> Update(Ordenes o)
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
                "DELETE FROM public.\"Ordenes\" WHERE \"Id\" = @Id", new { Id = id }
            ) > 0;
        }
    }

}
