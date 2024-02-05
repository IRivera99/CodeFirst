namespace API.Models;

public class AvionModel
{
    public Guid Id { get; set; }
    public string Matricula { get; set; }
    public string Modelo { get; set; }
    public int CantidadPasajeros { get; set; }
    public int AutonomiaKm { get; set; }
    public DateTime FechaAlta { get; set; }
    public FabricanteModel Fabricante { get; set; }
}
