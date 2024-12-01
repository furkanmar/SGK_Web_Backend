using Microsoft.EntityFrameworkCore;
using SGK_Web_Backend.Models;

namespace SGK_Web_Backend.DbConnection;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<deneme> denemeler { get; set; }

    public DbSet<User> users { get; set; }
    
}