using Polly;
using Polly.Extensions.Http;
using Refit;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Refit_tutorial.Model_Interface
{
    public static class RefitServiceExtension
    {
        public static IServiceCollection AddRefitClients(this IServiceCollection services)
        {
            var jsonSerializer = new NewtonsoftJsonContentSerializer();

            // Define retry policy (retry up to 3 times with exponential backoff)
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) // 2, 4, 8 seconds
                );

            // JSONPlaceholder API with retry
            services.AddRefitClient<I_PostService>(new RefitSettings { ContentSerializer = jsonSerializer })
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                })
                .AddPolicyHandler(retryPolicy);

            // Zanibal API with retry
            services.AddRefitClient<IZanibalApi>(new RefitSettings { ContentSerializer = jsonSerializer })
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://api.dev.mywealthcare.io");
                    c.DefaultRequestHeaders.Add("x-tenant-id", "enter tenant here");
                })
                .AddPolicyHandler(retryPolicy);

            return services;
        }
    }
}
