using Microsoft.AspNetCore.Mvc;
using SGK_Web_Backend.DbConnection;
using SGK_Web_Backend.Models;

namespace SGK_Web_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController:ControllerBase
{   
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public string HashPassword(string password, string salt)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password + salt));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower() + ":" + salt;
        }
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string[] parts = hashedPassword.Split(":");
        string salt = parts[1];

        return hashedPassword == HashPassword(password, salt);
    }

    // TODO: Change return types to IActionResult or something like that

    // TODO: Implement a session token for the user
    // TODO: Implement a logout function
    [HttpPost("login")]
    public string Login([FromBody] UserLoginDTO user_dto)
    {
        User? dbUser = _context.users.FirstOrDefault(u => u.username == user_dto.username);
        
        if (dbUser == null) 
            return "User not found!";
        
        if (VerifyPassword(user_dto.password, dbUser.password)) 
            return "User verified!"; // Create a session token here for the user
        
        return "Wrong password!";
    }

    [HttpPost("register")]
    public string CreateUser([FromBody] User newUser)
    {
        if (_context.users.Any(u => u.username == newUser.username))
            return "User already exists!"; 

        // Hash the password with a random salt for security
        newUser.password = HashPassword(newUser.password, 
            BCrypt.Net.BCrypt.GenerateSalt() // Generate a random salt
        );
        
        _context.users.Add(newUser);
        _context.SaveChanges();

        return "New user created!";
    }
    
}