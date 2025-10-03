namespace VentasWeb.Models.ViewModels
{
    public class VentaDetalleViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string ClienteNombre { get; set; } = "";
        public decimal Total { get; set; }
        public IEnumerable<VentaLineaVM> Detalles { get; set; } = Enumerable.Empty<VentaLineaVM>();

        public class VentaLineaVM
        {
            public int ProductoId { get; set; }
            public string ProductoNombre { get; set; } = "";
            public int Cantidad { get; set; }
            public decimal PrecioUnitario { get; set; }
            public decimal Subtotal { get; set; }
        }
    }
}
