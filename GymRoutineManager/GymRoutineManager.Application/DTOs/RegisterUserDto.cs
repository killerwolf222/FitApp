namespace GymRoutineManager.Application.Dtos
{
    
public class RegisterUserDto
    {
        public string FullName { get; set; } = string.Empty; // o Name
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

}
