using Gol.Business.Intefaces;
using Gol.Business.Notificacoes;
using Gol.Business.Services;
using Gol.Data.Context;
using Gol.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Gol.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
    }
}