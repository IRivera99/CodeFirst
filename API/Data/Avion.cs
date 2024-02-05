namespace API.Data;

public class Avion
{
    public Guid Id { get; set; }
    public string Matricula { get; set; }
    public string Modelo { get; set; }
    public int CantidadPasajeros { get; set; }
    public int AutonomiaKm { get; set; }
    public DateTime FechaAlta { get; set; }
    public Guid IdFabricante { get; set; }
    public Fabricante Fabricante { get; set; } = null!;
}
