using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuariosController : ControllerBase
{
    private readonly Context _context;

    public UsuariosController(Context context){
        _context = context;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UsuarioModel>> LogInUsuario(UsuarioLoginModel usuario){ 
        Usuario? user = await _context.Usuarios.FirstOrDefaultAsync(
            u => u.NombreUsuario.Equals(usuario.NombreUsuario) &&
            u.Password.Equals(usuario.Password));      
       
        if (user == null)
        {
            return Unauthorized("Usuario o contraseña incorrecta");      
        }
        
        if(user.Activo)
        {
            return Unauthorized("Usuario ya logueado");
        }

        user.Activo = true;
        await _context.SaveChangesAsync();

        UsuarioModel response = new UsuarioModel{
            NombreUsuario = user.NombreUsuario,
            FechaAlta = user.FechaAlta,
            Activo = user.Activo
        };

        return Ok(response);   
    }

    [HttpPost("Logout")]
    public async Task<ActionResult<bool>> LogOutUsuario(UsuarioLoginModel usuario){ 
        Usuario? user = await _context.Usuarios.FirstOrDefaultAsync(
            u => u.NombreUsuario.Equals(usuario.NombreUsuario) &&
            u.Password.Equals(usuario.Password));      
       
        if (user == null)
        {
            return Unauthorized("Usuario o contraseña incorrecta");      
        }
        
        if(!user.Activo)
        {
            return Unauthorized("Usuario no logueado...");
        }

        user.Activo = false;
        await _context.SaveChangesAsync();

        return Ok(true);   
    }

    [HttpPost("Create")]
    public async Task<ActionResult<UsuarioModel>> CreateUsuario(UsuarioLoginModel usuario){
        bool exist = await _context.Usuarios.AnyAsync(u => u.NombreUsuario.Equals(usuario.NombreUsuario));

        if(exist){
            return Unauthorized($"El usuario {usuario.NombreUsuario} ya existe");
        }

        Usuario nuevoUsuario = new Usuario
        {
            NombreUsuario = usuario.NombreUsuario,
            Password = usuario.Password,
            Activo = false,
            FechaAlta = DateTime.UtcNow
        };

        await _context.Usuarios.AddAsync(nuevoUsuario);
        await _context.SaveChangesAsync();

        UsuarioModel response = new UsuarioModel{
            NombreUsuario = nuevoUsuario.NombreUsuario,
            FechaAlta = nuevoUsuario.FechaAlta,
            Activo = nuevoUsuario.Activo
        };

        return Ok(response);
    }

    
}