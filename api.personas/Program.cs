using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using api.personas.Validation; // Ensure this matches your namespace for the validators
using Repository.Data; // Add this for repository access
using Services.Logica; // Add this for service access

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("postgres");

builder.Services.AddDbContext<Repository.Context.ContextAppDB>(options =>
{
    options.UseNpgsql(connString);
    options.UseValidationCheckConstraints();
});

// Register the ClienteRepository and ClienteService
builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ClienteValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<FacturaValidation>();

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