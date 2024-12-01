using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using SGK_Web_Backend.DbConnection;

var builder=WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(option=>
    option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    
builder.Services.Configure<HttpsRedirectionOptions>(option=>
{
    option.HttpsPort = null;
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();