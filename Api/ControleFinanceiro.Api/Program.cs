using ControleFinanceiro.Application.ServiceApplications;
using ControleFinanceiro.Common.Application;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Service;
using ControleFinanceiro.Common.Domain.Token;
using ControleFinanceiro.Common.Infrastructure.Repository;
using ControleFinanceiro.Domain.Helpers;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using ControleFinanceiro.Domain.Services;
using ControleFinanceiro.Repository.Context;
using ControleFinanceiro.Repository.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<ControleFinanceiroContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableDetailedErrors());
builder.Services.AddScoped<IUnitOfWork<ControleFinanceiroContext>, ControleFinanceiroContext>();
builder.Services.AddScoped<IUsuarioLogado, UsuarioLogado>();
builder.Services.AddScoped<IUsuarioLogadoRepository, UsuarioLogadoRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program));

//Repository
builder.Services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));

//Service
builder.Services.AddTransient(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
builder.Services.AddScoped(typeof(IAutenticacaoService<>), typeof(AutenticacaoService<>));

//Application
builder.Services.AddTransient(typeof(IApplicationBase<,,>), typeof(ApplicationBase<,,>));
builder.Services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
builder.Services.AddScoped(typeof(IAutenticacaoApplication<>), typeof(AutenticacaoApplication<>));

//Inicio Autenticação
var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

//Fim Autenticação

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
