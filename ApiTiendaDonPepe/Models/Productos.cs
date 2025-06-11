namespace ApiTiendaDonPepe.Models
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Categoria_id { get; set; }
        public int Proveedor_id { get; set; }
    }

}
