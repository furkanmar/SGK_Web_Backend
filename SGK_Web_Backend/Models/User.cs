namespace SGK_Web_Backend.Models;

public class User
{
    public Guid id { get; set; }
    public string student_id { get; set; }
    public string username { get; set; }
    public string email { get; set; } // school email
    public string password { get; set; } // hashed password with a salt: hash(password + salt)
    public string name { get; set; }
    public string surname { get; set; }
    public string phone_number { get; set; }
}