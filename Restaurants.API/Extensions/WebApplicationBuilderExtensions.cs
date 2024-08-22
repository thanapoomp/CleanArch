using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;

namespace Restaurants.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {

            builder.Services.AddAuthentication();

            // Add services to the container.
            builder.Services.AddControllers();

            // add swagger.
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearerAuth", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference {Type=ReferenceType.SecurityScheme,Id="bearerAuth"}
                        },[]
                    }
                });
            });

            //add endpoint for swagger
            builder.Services.AddEndpointsApiExplorer();

            // error handling middleware
            builder.Services.AddScoped<ErrorHandlingMiddleware>();

            // logging
            builder.Host.UseSerilog((context, configuration) =>
                configuration
                .ReadFrom.Configuration(context.Configuration)
            );
        }
    }
}
