using ControleFinanceiro.Application.ServiceApplications;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using ControleFinanceiro.Domain.Services;
using ControleFinanceiro.Repository.Context;
using ControleFinanceiro.Repository.Repositories;
using Generics.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.IoC
{
    public class ControleFinanceiroIoC
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork<ControleFinanceiroContext>, ControleFinanceiroContext>();
            //services.AddScoped<IUsuarioLogado, UsuarioLogado>();
            //services.AddScoped<IUser, User>();

            //Repository
            //services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));
            //services.AddScoped(typeof(IGastoRepository<>), typeof(GastoRepository<>));

            //Service
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
            //services.AddScoped(typeof(IGastoService<>), typeof(GastoService<>));

            //Application
            //services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
            //services.AddScoped(typeof(IGastoApplication<>), typeof(GastoApplication<>));
        }
    }
}
