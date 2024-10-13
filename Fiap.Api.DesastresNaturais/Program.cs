using AutoMapper;
using Fiap.Api.DesastresNaturais.Data.Contexts;
using Fiap.Api.DesastresNaturais.Data.Repository;
using Fiap.Api.DesastresNaturais.Logging;
using Fiap.Api.DesastresNaturais.Models;
using Fiap.Api.DesastresNaturais.Repository;
using Fiap.Api.DesastresNaturais.Services;
using Fiap.Api.DesastresNaturais.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

// REPOSITORIOS
#region 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDesastreNaturalRepository, DesastreNaturalRepository>();
#endregion

// SERVICES
#region Registro 
builder.Services.AddSingleton<ICustomLogger, MockLogger>();
builder.Services.AddScoped<IDesastreNaturalService,DesastreNaturalService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
// builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

// Configuração do AutoMapper
var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    c.AllowNullCollections = true;
    c.AllowNullDestinationValues = true;

    c.CreateMap<UsuarioModel, UsuarioViewModel>();
    c.CreateMap<UsuarioViewModel, UsuarioModel>();

    // Mapeamentos de DesastreNaturalModel
    c.CreateMap<RegistrarDesastreNaturalModel, DesastreNaturalViewModel>();
    c.CreateMap<DesastreNaturalViewModel, RegistrarDesastreNaturalModel>();

    // Mapeamentos adicionais para criação e atualização
    c.CreateMap<UsuarioCreateViewModel, UsuarioModel>();
    c.CreateMap<UsuarioUpdateViewModel, UsuarioModel>();

});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
