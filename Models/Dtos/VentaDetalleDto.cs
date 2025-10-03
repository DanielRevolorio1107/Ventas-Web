namespace VentasWeb.Models.Dtos
{
    public class VentaHeaderDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = "";
        public decimal Total { get; set; }
    }

    public class VentaLineaDto
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }

    public class VentaDetalleDto
    {
        public VentaHeaderDto Venta { get; set; } = new();
        public IEnumerable<VentaLineaDto> Detalles { get; set; } = Enumerable.Empty<VentaLineaDto>();
    }
}
