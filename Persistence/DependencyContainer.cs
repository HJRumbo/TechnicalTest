using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Persistence
{
    public static class DependencyContainer
    {
        public static void AddPersistences(this IServiceCollection services)
        {
            #region Inject Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            #endregion
        }
    }
}