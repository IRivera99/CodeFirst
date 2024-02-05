namespace API.Data;

public class Usuario
{
    public string NombreUsuario { get; set; } 
    public string Password { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaAlta { get; set; }
}
