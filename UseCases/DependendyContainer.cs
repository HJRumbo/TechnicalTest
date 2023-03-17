using Microsoft.Extensions.DependencyInjection;
using Ports.Input;
using UseCases.UseCases;

namespace UseCases
{
    public static class DependencyContainer
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ISavePersonInputPort, SavePersonUseCase>();
            services.AddScoped<ILoginInputPort, LoginUseCase>();
            services.AddScoped<IGetAllPeopleInputPort, GetAllPeopleUseCase>();
        }
    }
}