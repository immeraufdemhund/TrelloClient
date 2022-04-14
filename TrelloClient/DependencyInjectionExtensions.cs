using System;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using TrelloClient;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        /// Initializes the TrelloRestClient and sets up the settings. You'll need to have a trello section with both key and token values set
        /// </summary>
        /// <exception cref="Exception">throws exception if trello section is missing from IConfiguration, or if token and/or key are missing from said section</exception>
        public static IServiceCollection AddTrelloRestClient(this IServiceCollection services)
        {
            services
                .AddHttpClient<TrelloRestClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var settings = provider.GetService<IOptions<TrelloClientSettings>>().Value;
                    client.BaseAddress = new Uri("https://api.trello.com/");
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("OAuth", $"oauth_consumer_key=\"{settings.Key}\", oauth_token=\"{settings.Token}\"");
                })
                .Services
                .AddOptions<TrelloClientSettings>()
                .Configure<IConfiguration>((option, configuration) =>
                {
                    var section = configuration.GetSection("trello");
                    if (!section.Exists())
                        throw new Exception("Missing trello section from configuration options. Make sure you have a section called trello with your key and token");
                    if (string.IsNullOrEmpty(section["key"]) && string.IsNullOrEmpty(section["token"]))
                    {
                        throw new Exception("trello section is missing both key and token values");
                    }

                    if (string.IsNullOrEmpty(section["token"]))
                    {
                        throw new Exception("trello section is missing token value");
                    }
                    option.Key = string.IsNullOrEmpty(section["key"]) ?
                        throw new Exception("trello section is missing key value") :
                        section["key"];

                    option.Token = string.IsNullOrEmpty(section["token"]) ?
                        throw new Exception("trello section is missing token value") :
                        section["token"];
                });

            return services;
        }
    }
}
