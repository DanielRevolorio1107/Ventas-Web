namespace VentasWeb.Models;

public class DetalleVentaRequest
{
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
}

public class NuevaVentaRequest
{
    public int ClienteId { get; set; }
    public DateTime? Fecha { get; set; } 
    public List<DetalleVentaRequest> Detalles { get; set; } = new();
}



