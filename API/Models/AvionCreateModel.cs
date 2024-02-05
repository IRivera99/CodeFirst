namespace API.Models;

public class AvionCreateModel
{
    public string Matricula { get; set; }
    public string Modelo { get; set; }
    public int CantidadPasajeros { get; set; }
    public int AutonomiaKm { get; set; }
    public Guid IdFabricante { get; set; }
}
