using AutoMapper;
using Dormitories.Core.BusinessLogic.Managers;
using Dormitories.Core.DataAccess.Models;
using Dormitories.Core.DataAccess.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

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
                .AddEntityFrameworkSqlServer()
                .AddDbContext<TContext>(serviceLifetime);

            return services;
        }
        public static IServiceCollection AddCoreIntegrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(config =>
            {
                config.UseSqlServer("Data Source=DESKTOP-EC5FMB7\\SQLEXPRESS;Initial Catalog=Dormitory;Integrated Security=True;");
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IRoomManager, RoomManager>();
            services.AddTransient<IDormitoryManager, DormitoryManager>();

            return services;
        }
   }
}
