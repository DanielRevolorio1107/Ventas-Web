using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using VentasWeb.Models.Dtos;
using VentasWeb.Models.ViewModels;

namespace VentasWeb.Controllers
{
    public class VentasController : Controller
    {
        private readonly IHttpClientFactory _http;
        private readonly IConfiguration _cfg;

        public VentasController(IHttpClientFactory http, IConfiguration cfg)
        {
            _http = http;
            _cfg = cfg;
        }

        // GET /Ventas/Historial?clienteId=1
        [HttpGet]
        public async Task<IActionResult> Historial(int? clienteId)
        {
            var api = _cfg["ApiBaseUrl"] ?? "";
            var http = _http.CreateClient();
            var clientes = await http.GetFromJsonAsync<IEnumerable<ClientDto>>($"{api}/api/clientes")
                           ?? Enumerable.Empty<ClientDto>();
            IEnumerable<VentaItemDto> ventas = Enumerable.Empty<VentaItemDto>();
            if (clienteId.HasValue && clienteId.Value > 0)
            {
                ventas = await http.GetFromJsonAsync<IEnumerable<VentaItemDto>>(
                             $"{api}/api/ventas/cliente/{clienteId.Value}")
                         ?? Enumerable.Empty<VentaItemDto>();
            }

            var vm = new HistorialViewModel
            {
                ApiBaseUrl = api,
                Clientes   = clientes,
                ClienteId  = clienteId,
                Ventas     = ventas
            };

            return View(vm);
        }

        //  GET /api/ventas/{id}
        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var api  = _cfg["ApiBaseUrl"] ?? "";
            var http = _http.CreateClient();
            var dto = await http.GetFromJsonAsync<VentaDetalleDto>($"{api}/api/ventas/{id}");
            if (dto is null) return NotFound();
            var vm = new VentaDetalleViewModel
            {
                Id            = dto.Venta.Id,
                Fecha         = dto.Venta.Fecha,
                ClienteNombre = dto.Venta.ClienteNombre,
                Total         = dto.Venta.Total,
                Detalles      = dto.Detalles.Select(d => new VentaDetalleViewModel.VentaLineaVM
                {
                    ProductoId     = d.ProductoId,
                    ProductoNombre = d.ProductoNombre,
                    Cantidad       = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal       = d.Subtotal
                })
            };

            return View(vm);
        }

        // GET /Ventas/Create 
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var api  = _cfg["ApiBaseUrl"] ?? "";
            var http = _http.CreateClient();

            var productos = await http.GetFromJsonAsync<IEnumerable<ProductDto>>($"{api}/api/productos") 
                            ?? Enumerable.Empty<ProductDto>();
            var clientes  = await http.GetFromJsonAsync<IEnumerable<ClientDto>>($"{api}/api/clientes")
                            ?? Enumerable.Empty<ClientDto>();

            var vm = new NuevaVentaViewModel
            {
                ApiBaseUrl = api,
                Productos  = productos,
                Clientes   = clientes
            };

            return View(vm);
        }
    }
}
