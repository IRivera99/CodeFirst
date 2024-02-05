namespace API.Data;

public class Fabricante
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public ICollection<Avion> Aviones { get; set; } = new List<Avion>();
}
