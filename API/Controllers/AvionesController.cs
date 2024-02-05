using System.Security.Cryptography.X509Certificates;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("Aviones")]
public class AvionesController : ControllerBase
{
    private readonly Context _context;

    public AvionesController(Context context){
        _context = context;
    }

    [HttpGet("Get")]
    public async Task<ActionResult<List<AvionModel>>> GetAviones(){
        List<AvionModel> aviones = new List<AvionModel>();
        aviones = await _context.Aviones
            .Include(x => x.Fabricante)
            .Select(x => new AvionModel{
                Id = x.Id,
                Matricula = x.Matricula,
                Modelo = x.Modelo,
                CantidadPasajeros = x.CantidadPasajeros,
                AutonomiaKm = x.AutonomiaKm,
                FechaAlta = x.FechaAlta,
                Fabricante = new FabricanteModel{
                    Id = x.IdFabricante,
                    Nombre = x.Fabricante.Nombre
                    }
            })
            .ToListAsync();
        return Ok(aviones);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<AvionModel>> CreateAvion(AvionCreateModel avion){
        if(avion.Modelo == "" || avion.Modelo == "" || avion.AutonomiaKm < 1 || avion.CantidadPasajeros < 1 || avion.IdFabricante == Guid.Empty){
            return Unauthorized("Error en los datos a guardar");
        }
        
        bool existe = await _context.Aviones.AnyAsync(a => a.Matricula.Equals(avion.Matricula) || a.Modelo.Equals(avion.Modelo));
        bool existeFabricante = await _context.Fabricantes.AnyAsync(f => f.Id == avion.IdFabricante);       

        if(existe){
            return Unauthorized("Error, existe un avión que posee el mismo nombre de modelo o matrícula...");
        }

        if(!existeFabricante){
            return Unauthorized("Error, no existe el fabricante...");
        }

        Avion nuevoAvion = new Avion{
            Id = Guid.NewGuid(),
            Matricula = avion.Matricula,
            Modelo = avion.Modelo,
            CantidadPasajeros = avion.CantidadPasajeros,
            AutonomiaKm = avion.AutonomiaKm,
            FechaAlta = DateTime.UtcNow,
            IdFabricante = avion.IdFabricante,
        };

        await _context.Aviones.AddAsync(nuevoAvion);
        await _context.SaveChangesAsync();

        AvionModel? response = await _context.Aviones
            .Include(x => x.Fabricante)
            .Select(x => new AvionModel{
                Id = x.Id,
                Matricula = x.Matricula,
                Modelo = x.Modelo,
                CantidadPasajeros = x.CantidadPasajeros,
                AutonomiaKm = x.AutonomiaKm,
                FechaAlta = x.FechaAlta,
                Fabricante = new FabricanteModel{
                    Id = x.IdFabricante,
                    Nombre = x.Fabricante.Nombre
                    }
            })
            .Where(x => x.Id.Equals(nuevoAvion.Id))
            .FirstOrDefaultAsync();

        return Ok(response);

    }
}
