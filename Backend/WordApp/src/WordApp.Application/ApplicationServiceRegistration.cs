﻿using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WordApp.Application.Base;
using WordApp.Application.Behaviours;
using WordApp.Application.Exceptions;

namespace WordApp.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddValidatorsFromAssembly(assembly);

        services.AddTransient<ExceptionMiddleware>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

        return services;
    }

    private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
    {
        var rules = assembly.GetTypes().Where(p => p.IsSubclassOf(type) && p != type);

        foreach (var rule in rules)
            services.AddTransient(rule);
        return services;
    }
}
