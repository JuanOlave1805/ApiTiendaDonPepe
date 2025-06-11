using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Dapper;
using Npgsql;

namespace ApiTiendaDonPepe.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IConfiguration _config;
        public ProductoRepository(IConfiguration config) => _config = config;

        private NpgsqlConnection GetConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Productos>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Productos>("SELECT * FROM public.\"Productos\"");
        }

        public async Task<Productos> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Productos>(
                "SELECT * FROM public.\"Productos\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public async Task<int> Create(Productos p)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO public.""Productos"" (""Nombre"", ""Precio"", ""Stock"", ""Categoria_id"", ""Proveedor_id"") 
                VALUES (@Nombre, @Precio, @Stock, @Categoria_id, @Proveedor_id);";
            return await conn.ExecuteAsync(sql, p);
        }

        public async Task<bool> Update(Productos p)
        {
            using var conn = GetConnection();
            var sql = @"UPDATE public.""Productos"" 
                SET ""Nombre"" = @Nombre, 
                    ""Precio"" = @Precio, 
                    ""Stock"" = @Stock,
                    ""Categoria_id"" = @Categoria_id, 
                    ""Proveedor_id"" = @Proveedor_id 
                WHERE ""Id"" = @Id";
            return await conn.ExecuteAsync(sql, p) > 0;
        }


        public async Task<bool> Delete(int id)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(
                "DELETE FROM public.\"Productos\" WHERE \"Id\" = @Id", new { Id = id }
            ) > 0;
        }
    }

}
