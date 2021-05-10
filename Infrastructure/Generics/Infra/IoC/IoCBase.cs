using Generics.Application;
using Generics.Domain.Interfaces;
using Generics.Domain.Service;
using Generics.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Infra.IoC
{
    public class IoCBase
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient(typeof(IApplicationBase<,,>), typeof(ApplicationBase<,,>));
            services.AddTransient(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
            services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
        }
    }
}
