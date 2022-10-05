namespace CarsWebApp.DTOs
{
    public class UserCreateDTO
    {
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}
