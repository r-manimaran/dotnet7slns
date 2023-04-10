using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.RateLimiting;

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
        public static void AddRateLimitingFixedWindow(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("FixedWindowPolicy",opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(5);
                    opt.QueueLimit = 10;
                    opt.PermitLimit = 5;
                    opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
        }
        
        public static void AddRateLimitingSlidingWindow(this IServiceCollection services)
        {
            services.AddRateLimiter(option =>
            {
                option.AddSlidingWindowLimiter("SlidingWindowPolicy", opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(10);
                    opt.PermitLimit = 4;
                    opt.QueueLimit = 3;
                    opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    opt.SegmentsPerWindow = 3;
                }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
        }

        public static void AddRateLimitingConcurrent(this IServiceCollection services)
        {
            services.AddRateLimiter(option =>
            {
                option.AddConcurrencyLimiter("ConcurrentRatePolicy", opt =>
                {
                    opt.QueueLimit = 5;
                    opt.PermitLimit = 3;
                    opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
        }

        public static void AddRateLimitingTokenBucket(this IServiceCollection services)
        {
            services.AddRateLimiter(option => 
            {
                option.AddTokenBucketLimiter("TokenBucketPolicy", opt =>
                {
                    opt.TokenLimit = 4; //How much Token it can hold in a Bucket
                    opt.QueueLimit = 2;
                    opt.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    opt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
                    opt.TokensPerPeriod = 4; // Max number of token to restore in each replenishment
                    opt.AutoReplenishment = true;
                }).RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });
        }

    }
}
