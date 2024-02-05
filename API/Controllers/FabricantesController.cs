using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("Fabricantes")]
public class FabricantesController : ControllerBase
{
    private readonly Context _context;

    public FabricantesController(Context context){
        _context = context;
    }

    [HttpGet("Get")]
    public async Task<ActionResult<List<FabricanteModel>>> GetFabricantes(){
        List<FabricanteModel> fabricantes;        
        fabricantes = await _context.Fabricantes
            .Select(x => new FabricanteModel{
                Id = x.Id,
                Nombre = x.Nombre
            })
            .ToListAsync();
        return Ok(fabricantes);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<FabricanteModel>> CreateFabricante(FabricanteCreateModel fabricante){
        bool exist = await _context.Fabricantes.AnyAsync(f => f.Nombre.Equals(fabricante.Nombre));

        if(exist){
            return Unauthorized($"Fabricante con el nombre '{fabricante.Nombre}' ya existe...");
        }

        Fabricante nuevoFabricante = new Fabricante{
            Id = Guid.NewGuid(),
            Nombre = fabricante.Nombre
        };

        await _context.Fabricantes.AddAsync(nuevoFabricante);
        await _context.SaveChangesAsync();

        FabricanteModel response = new FabricanteModel{
            Id = nuevoFabricante.Id,
            Nombre = nuevoFabricante.Nombre
        };

        return Ok(nuevoFabricante);
    }
}
