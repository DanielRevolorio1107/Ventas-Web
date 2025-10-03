using System.ComponentModel.DataAnnotations;

namespace VentasWeb.Models;

public class ClientDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    [EmailAddress] public string Email { get; set; } = string.Empty;
}
