using System;
using ForecastCore.Interfaces;
using ForecastCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;

namespace ForecastWebAppAngular.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
    {
        var url = config["MeteoLt:BaseUrl"];
        if (url == null)
            throw new ArgumentNullException("Not found MeteoLt base url in settings!");

        services.AddHttpClient<IForecastService, MeteoLtForecastService>(client =>
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });

        return services;
    }

    public static IServiceCollection AddDependencyGroup(
         this IServiceCollection services)
    {
       // Add your own dependency

        return services;
    }
}

