using Microsoft.AspNetCore.Mvc.Versioning;

namespace APiVersioningRateLimit.Extensions
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Add API Version Settings
        /// </summary>
        /// <param name="services"></param>
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.ApiVersionReader = ApiVersionReader.Combine(
                    // new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("x-version")//,
                    //new MediaTypeApiVersionReader("ver")
                  );
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }

        /// <summary>
        /// Add Rate Limit Information
        /// </summary>
        /// <param name="services"></param>
        public static void AddRateLimiting(this IServiceCollection services)
        {

        }

    }
}
