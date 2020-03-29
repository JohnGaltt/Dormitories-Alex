using Dormitories.Core.DataAccess.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dormitories.Core.DataAccess
{
    public static class Extensions
    {
        public static IServiceCollection AddApplicationDbContext<TContext>(this IServiceCollection services, DatabaseSettings databaseSettings, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
           where TContext : DbContext
        {
            if (databaseSettings == null)
            {
                throw new ArgumentNullException(nameof(databaseSettings));
            }

            services
                .AddSingleton(Options.Create(databaseSettings))
                .AddDbContext<TContext>(serviceLifetime);

            return services;
        }
    }
}
