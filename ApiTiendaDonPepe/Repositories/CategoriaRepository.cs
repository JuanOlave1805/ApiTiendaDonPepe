using ApiTiendaDonPepe.Interfaces;
using ApiTiendaDonPepe.Models;
using Dapper;
using Npgsql;

namespace ApiTiendaDonPepe.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IConfiguration _config;
        public CategoriaRepository(IConfiguration config) => _config = config;

        private NpgsqlConnection GetConnection() =>
            new(_config.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<Categorias>> GetAll()
        {
            using var conn = GetConnection();
            return await conn.QueryAsync<Categorias>("SELECT * FROM public.\"Categorias\"");
        }

        public async Task<Categorias> GetById(int id)
        {
            using var conn = GetConnection();
            return await conn.QueryFirstOrDefaultAsync<Categorias>(
                "SELECT * FROM public.\"Categorias\" WHERE \"Id\" = @Id", new { Id = id });
        }

        public async Task<int> Create(Categorias p)
        {
            using var conn = GetConnection();
            var sql = @"INSERT INTO public.""Categorias"" (""Nombre"") 
                VALUES (@Nombre);";
            return await conn.ExecuteAsync(sql, p);
        }

        public async Task<bool> Update(Categorias p)
        {
            using var conn = GetConnection();
            var sql = @"UPDATE public.""Categorias"" 
                SET ""Nombre"" = @Nombre 
                WHERE ""Id"" = @Id";
            return await conn.ExecuteAsync(sql, p) > 0;
        }


        public async Task<bool> Delete(int id)
        {
            using var conn = GetConnection();
            return await conn.ExecuteAsync(
                "DELETE FROM public.\"Categorias\" WHERE \"Id\" = @Id", new { Id = id }
            ) > 0;
        }
    }

}
