using Generics.Domain.Interfaces;
using Generics.Infra.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Generics.Infra.Context
{
    public class ContextBase<TContext> : DbContext, IUnitOfWork<TContext>
                        where TContext : DbContext
    {
        protected ContextBase(DbContextOptions<TContext> options) : base(options) { }

        protected virtual void RegisterMappings(ModelBuilder modelBuilder, Assembly assembly)
        {
            var typesToRegister = assembly.GetTypes()
                    .Where(type => !string.IsNullOrEmpty(type.Namespace)
                    && type.BaseType != null && type.BaseType.IsGenericType
                    && type.BaseType.GetGenericTypeDefinition() == typeof(EntityBaseMap<,>));

            foreach (Type type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
        public int Commit() => SaveChanges();
    }
}
