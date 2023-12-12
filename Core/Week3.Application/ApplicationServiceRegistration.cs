using Microsoft.Extensions.DependencyInjection;
using Week3.Application.Services.UserService;

namespace Week3.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }
}
