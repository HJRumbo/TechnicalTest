using Microsoft.Extensions.DependencyInjection;
using Presenters;
using Persistence;
using UseCases;
using JsonWebTokenService;

namespace IoC
{
    public static class DependencyContainer
    {
        public static void AddDependecies(this IServiceCollection services)
        {
            services.AddPersistences();
            services.AddUseCases();
            services.AddPresenters();
            services.AddJwtService();
        }
    }
}