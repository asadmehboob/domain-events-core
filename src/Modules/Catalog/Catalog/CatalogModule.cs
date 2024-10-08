﻿using Catalog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared;
using System.Reflection;

namespace Catalog;
public static class CatalogModule
{
    public static IServiceCollection AddCatalogModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Add services to the container.
        string? connectionString = configuration.GetConnectionString("CatalogConnectionString");


        services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
        
        services.AddDbContext<CatalogDbContext>((sp,options) => {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        } );
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<ICatalogRepository, EfCatalogRepository>();
        services.AddScoped<ICatalogService, CatalogService>();

        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        // Configure the HTTP request pipeline.
        //app
        //    .UseApplicationServices()
        //    .UseInfrastructureServices()
        //    .UseApiServices();

        return app;
    }

    public static IMvcBuilder AddCatalogModule(this IMvcBuilder builder)
    {
        //return builder.AddApplicationPart(Assembly.GetExecutingAssembly());
        //builder.AddApplicationPart(typeof(AccountController).Assembly);
        return builder;


    }
}
