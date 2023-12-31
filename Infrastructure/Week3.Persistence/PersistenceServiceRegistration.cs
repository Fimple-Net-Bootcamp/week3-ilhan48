﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Week3.Application.Services.Repositories;
using Week3.Persistence.Context;
using Week3.Persistence.Repositories;

namespace Week3.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VirtualPetDbContext>(
            options => options.UseNpgsql(configuration.GetConnectionString("Default")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IHealthStatusRepository, HealthStatusRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IFoodRepository, FoodRepository>();

        return services;
        
    }
}
 