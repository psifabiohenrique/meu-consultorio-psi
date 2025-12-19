using MeuConsultorioPsi.Application.Services.Patient;
using MeuConsultorioPsi.Application.Services.Therapist;
using MeuConsultorioPsi.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("sqlite");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connection));

// Registrar serviços de Patient
builder.Services.AddScoped<CreatePatientService>();
builder.Services.AddScoped<ReadPatientService>();
builder.Services.AddScoped<ReadAllPatientsService>();
builder.Services.AddScoped<UpdatePatientService>();

// Registrar serviços de Therapist
builder.Services.AddScoped<CreateTherapistService>();
builder.Services.AddScoped<ReadTherapistService>();
builder.Services.AddScoped<ReadAllTherapistsService>();
builder.Services.AddScoped<UpdateTherapistService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
