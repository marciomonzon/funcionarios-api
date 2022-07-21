using AutoMapper;
using Funcionarios.Domain.Interfaces.Repositories;
using Funcionarios.Domain.Interfaces.Services;
using Funcionarios.Domain.Mappings;
using Funcionarios.Domain.Services;
using Funcionarios.Infrastructure.Data;
using Funcionarios.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IFuncaoService, FuncaoService>();
builder.Services.AddScoped<IFuncionarioCLTService, FuncionarioCLTService>();
builder.Services.AddScoped<IFuncionarioPJService, FuncionarioPJService>();

builder.Services.AddScoped<ICargoRepository, CargoRepository>();
builder.Services.AddScoped<IFuncaoRepository, FuncaoRepository>();
builder.Services.AddScoped<IFuncionarioCLTRepository, FuncionarioCLTRepository>();
builder.Services.AddScoped<IFuncionarioPJRepository, FuncionarioPJRepository>();

builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration
                .GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
