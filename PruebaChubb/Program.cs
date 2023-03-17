using PruebaChubb.API;
using PruebaChubb.Business;
using PruebaChubb.CI.Actions;
using PruebaChubb.Data.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapping();
builder.Services.AddActions();

builder.Services.AddScoped<IRuletaBusinessAction, RuletaBL>();
builder.Services.AddScoped<IRuletaRepositoryAction, RuletaDal>();

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
