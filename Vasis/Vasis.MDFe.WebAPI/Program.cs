using Vasis.MDFe.Core.Interfaces.External;
using Vasis.MDFe.Infrastructure.External;

var builder = WebApplication.CreateBuilder(args);

// WebAPI/Program.cs - Adicionar ao container
builder.Services.AddScoped<IZeusMDFeWrapper, ZeusMDFeWrapper>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Tornar Program acessível para testes de integração
public partial class Program { }