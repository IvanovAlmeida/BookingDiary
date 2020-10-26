using BD.API.Extensions;
using BD.Business.Interfaces;
using BD.Business.Notifications;
using BD.Business.Services;
using BD.Data.Context;
using BD.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BD.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<IReserveRepository, ReserveRepository>();
            services.AddScoped<IReserveService, ReserveService>();

            services.AddScoped<IReserveItemRepository, ReserveItemRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            services.AddScoped<ICashFlowRespository, CashFlowRepository>();

            services.AddScoped<INotificator, Notificator>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
