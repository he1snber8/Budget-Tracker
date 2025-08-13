using Project_Backend_2024.DTO;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<TechStack>();
var app = builder.Build();
app.MapControllers();
app.Run();