namespace SGK_Web_Backend.Models;

public class UserLoginDTO
{
    public string username { get; set; }
    public string password { get; set; } // hashed password with a salt: hash(password + salt)
}