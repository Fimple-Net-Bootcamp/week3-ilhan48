using Microsoft.Extensions.DependencyInjection;
using Week3.Application.Services.ActivityService;
using Week3.Application.Services.HealthStatusService;
using Week3.Application.Services.PetService;
using Week3.Application.Services.UserService;

namespace Week3.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPetService, PetService>();
        services.AddScoped<IHealthStatusService, HealthStatusService>();
        services.AddScoped<IActivityService, ActivityService>();
        return services;
    }
}
