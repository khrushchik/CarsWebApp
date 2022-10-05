namespace CarsWebApp.Domains
{
    public class UserCreateDomain
    {
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}
