using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SGK_Web_Backend.DbConnection;
using SGK_Web_Backend.Models;


namespace SGK_Web_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class denemeController:ControllerBase
{   
    private readonly AppDbContext _context;

    public denemeController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public string GetAll_deneme_object()
    {
        deneme deneme = new deneme();
        deneme.Ad = "furkan";
        deneme.Soyad = "marif";
        deneme.Email = "furkan@gmail.com";
        deneme.Telefon="123456";
        
        _context.denemeler.Add(deneme);
        _context.SaveChanges();
        return "done";
    }
}