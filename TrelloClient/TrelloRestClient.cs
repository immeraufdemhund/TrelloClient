using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TrelloClient
{
    public class TrelloRestClient : IDisposable
    {
        private readonly ILogger _logger;
        private readonly HttpClient _client;

        public TrelloRestClient(ILogger<TrelloRestClient> logger, HttpClient httpClient)
        {
            _client = httpClient;
            _logger = logger;
        }

        public async Task<string> SendRequest(ITrelloClientRequest request, CancellationToken cancellationToken)
        {
            var response = await _client.SendAsync(request.ToRequestMessage(), cancellationToken);
            return await GetSuccessfulContent(response);
        }

        public async Task<JToken> SendRequestJToken(ITrelloClientRequest request, CancellationToken cancellationToken)
        {
            var response = await _client.SendAsync(request.ToRequestMessage(), cancellationToken);
            return await GetSuccessfulContentAsJToken(response, cancellationToken);
        }

        internal async Task<T> GetSuccessfulContent<T>(HttpResponseMessage g)
        {
            return JsonConvert.DeserializeObject<T>(await GetSuccessfulContent(g));
        }

        private async Task<JToken> GetSuccessfulContentAsJToken(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            await using var stream = await response.Content.ReadAsStreamAsync();
            using var streamReader = new StreamReader(stream);
            using var reader = new JsonTextReader(streamReader);
            var token = await JToken.LoadAsync(reader, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Problem with request {JTokenContent}", token);
            }

            response.EnsureSuccessStatusCode();
            return token;
        }

        private async Task<string> GetSuccessfulContent(HttpResponseMessage g)
        {
            var content = await g.Content.ReadAsStringAsync();
            if (!g.IsSuccessStatusCode)
            {
                _logger.LogError(content);
            }

            g.EnsureSuccessStatusCode();
            return content;
        }

        public void Dispose() => _client.Dispose();
    }
}
