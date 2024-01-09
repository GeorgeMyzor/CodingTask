using CodingTask.Middleware;
using CodingTask.Repositories;
using CodingTask.Services;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetSection("ConnectionString").Get<string>();
builder.Services.AddScoped<IDbConnection>(c => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<FacilityRepository>();
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<FacilityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
