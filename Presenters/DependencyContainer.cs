using Ports.Output;
using Microsoft.Extensions.DependencyInjection;
using Presenters.Presenters;

namespace Presenters
{
    public static class DependencyContainer
    {
        public static void AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<ISavePersonOutputPort, SavePersonPresenter>();
            services.AddScoped<ILoginOutputPort, LoginPresenter>();
            services.AddScoped<IGetAllPeopleOutputPort, GetAllPeoplePresenter>();
        }
    }
}