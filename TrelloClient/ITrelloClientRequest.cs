using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace TrelloClient
{
    public interface ITrelloClientRequest
    {
        HttpRequestMessage ToRequestMessage();
    }

    public abstract class TrelloClientRequest : ITrelloClientRequest
    {
        protected abstract HttpMethod HttpMethod { get; }
        /// <summary> In a uri it is after the host and before the query </summary>
        /// <example> <code>https://api.trello.com/1/cards/asdf/attachments?name=asdf&amp;mimetype=json</code>  it is <code>/1/cards/asdf/attachments</code> </example>
        protected abstract string LocalPath { get; }

        protected void SetQueryParameter(string name, object value) => _queryParameters[name] = value.ToString();
        private readonly Dictionary<string, string> _queryParameters = new Dictionary<string, string>();

        private string Query
        {
            get
            {
                if (!_queryParameters.Any()) return "";
                return "?" + string.Join("&", _queryParameters.Select(x => $"{x.Key}={System.Net.WebUtility.UrlEncode(x.Value)}"));
            }
        }
        public HttpRequestMessage ToRequestMessage()
        {
            return new HttpRequestMessage(HttpMethod, LocalPath + Query);
        }
    }
}
