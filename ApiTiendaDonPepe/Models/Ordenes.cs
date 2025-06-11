namespace ApiTiendaDonPepe.Models
{
    public class Ordenes
    {
        public int Id { get; set; }
        public int Usuario_id { get; set; }
        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
