var builder = WebApplication.CreateBuilder(args);


// Configurar Kestrel para HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
  options.ListenAnyIP(5000); // Porta HTTP
});

builder.Services.AddSingleton<IGpioService, GpioService>();
builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();