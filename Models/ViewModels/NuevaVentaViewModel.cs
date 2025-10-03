using VentasWeb.Models.Dtos;

namespace VentasWeb.Models.ViewModels
{
    public class NuevaVentaViewModel
    {
        public string ApiBaseUrl { get; set; } = string.Empty;
        public IEnumerable<ProductDto> Productos { get; set; } = Enumerable.Empty<ProductDto>();
        public IEnumerable<ClientDto> Clientes { get; set; } = Enumerable.Empty<ClientDto>();
    }
}
