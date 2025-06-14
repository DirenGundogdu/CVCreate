using Users.Application.Interfaces;

namespace Users.Infrastructure;

public class PasswordHasher: IPasswordHasher
{
    public string Hash(string password)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool Verify(string hashedPassword, string providedPassword)
    {
        return Hash(providedPassword) == hashedPassword;
    }
    
}