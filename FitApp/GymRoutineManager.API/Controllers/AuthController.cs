using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Application.Dtos;  // <-- Asegúrate de que esta ruta coincida con tu proyecto
using GymRoutineManager.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace GymRoutineManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly GymContext _context;

        public AuthController(GymContext context)
        {
            _context = context;
        }

[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
{
    if (string.IsNullOrWhiteSpace(userDto.Username) || string.IsNullOrWhiteSpace(userDto.Password) || string.IsNullOrWhiteSpace(userDto.Email) || string.IsNullOrWhiteSpace(userDto.FullName))
        return BadRequest("Todos los campos son obligatorios.");

    if (await _context.Users.AnyAsync(u => u.Username == userDto.Username))
        return BadRequest("El usuario ya existe.");

    var user = new User
    {
        FullName = userDto.FullName,
        Username = userDto.Username,
        Email = userDto.Email,
        PasswordHash = HashPassword(userDto.Password),
        FechaRegistro = DateTime.Now,
        Rol = "Usuario"
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();

    return Ok("Usuario registrado correctamente.");
}


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var dbUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (dbUser == null)
                return Unauthorized("Usuario o contraseña incorrectos.");

            var hash = HashPassword(user.PasswordHash);
            if (dbUser.PasswordHash != hash)
                return Unauthorized("Usuario o contraseña incorrectos.");

            return Ok(new { message = "Login exitoso", username = dbUser.Username, rol = dbUser.Rol });
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
