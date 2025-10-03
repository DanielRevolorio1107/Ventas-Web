using VentasWeb.Models.Dtos;

namespace VentasWeb.Models.ViewModels
{
    public class HistorialViewModel
    {
        public string ApiBaseUrl { get; set; } = string.Empty;
        public IEnumerable<ClientDto> Clientes { get; set; } = Enumerable.Empty<ClientDto>();
        public int? ClienteId { get; set; }
        public IEnumerable<VentaItemDto> Ventas { get; set; } = Enumerable.Empty<VentaItemDto>();
    }
}
