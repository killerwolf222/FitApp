namespace GymRoutineManager.Domain.Entities
{
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;  
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
    public string Rol { get; set; } = "Usuario";
}

}