using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.Generation.Processors.Security;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.React.Ssr.Web.Configuration.Filters;
using Umbraco.React.Ssr.Web.Features.Blocks.Converters;
using Umbraco.React.Ssr.Web.Features.Ssr.Controllers;

namespace Umbraco.React.Ssr.Web.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebUIServices(this IServiceCollection services, IWebHostEnvironment env, IConfiguration config)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddHttpContextAccessor();

        services.AddHealthChecks();

        var settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Objects,
            Formatting = Newtonsoft.Json.Formatting.Indented
        };

        services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
            .AddRazorRuntimeCompilation()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new BlockDtoJsonConverter());
            });
        ;

        services.AddFluentValidationAutoValidation();

        services.AddRazorPages();

        services.AddCors(options =>
        {
            options.AddPolicy(name: "react-app",
                policy =>
                {
                    policy.WithOrigins("http://localhost:3000", "http://localhost:7000");
                });
        });

        //Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "Umbraco.React.Ssr API";
            
            // Some operations may require login in Umbraco, change this appropriately when known.
            configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the textbox: Bearer {your JWT token}."
            });

            configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        if(env.IsDevelopment()) {
            services.AddUmbraco(env, config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                .Build();
        }
        else {
            services.AddUmbraco(env, config)
                .AddBackOffice()
                .AddWebsite()
                .AddComposers()
                // .AddAzureBlobMediaFileSystem() // Enable when AzureBlob storage is configured
                .Build();
        }

        services.Configure<UmbracoRenderingDefaultsOptions>(c =>
        {
            c.DefaultControllerType = typeof(SsrDataController);
        });

        return services;
    }
}
