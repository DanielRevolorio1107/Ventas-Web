using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using VentasWeb.Models;

namespace VentasWeb.Controllers;

public class ProductosController : Controller
{
    private readonly IHttpClientFactory _http;
    public ProductosController(IHttpClientFactory http) => _http = http;

    public async Task<IActionResult> Index()
    {
        var client = _http.CreateClient("Api");
        var resp = await client.GetAsync("api/productos");
        resp.EnsureSuccessStatusCode();

        await using var stream = await resp.Content.ReadAsStreamAsync();
        var productos = await JsonSerializer.DeserializeAsync<List<ProductDto>>(
            stream,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(productos ?? new());
    }
}
