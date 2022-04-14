using System.Net.Http;
using TrelloClient.Models;

namespace TrelloClient.Requests.Cards
{
    public class CardsAddAttachmentRequest : CardsRequest
    {
        protected override HttpMethod HttpMethod => HttpMethod.Post;
        protected override string LocalPath => base.LocalPath + $"/{_cardId}/attachments";

        /// <summary> The name of the attachment.Max length 256. </summary>
        public string Name { set => SetQueryParameter("name", value); }
        /// <summary> The file to attach, as multipart/form-data Format: binary</summary>
        public string File { set =>  SetQueryParameter("file", value); }
        /// <summary> The mimeType of the attachment. Max length 256</summary>
        public string MimeType { set =>  SetQueryParameter("mimeType", value); }
        /// <summary> A URL to attach. Must start with http:// or https://</summary>
        public string Url { set => SetQueryParameter("url", value); }
        /// <summary> Determines whether to use the new attachment as a cover for the Card. Default: false</summary>
        public bool SetCover { set => SetQueryParameter("setCover", value); }

        private readonly CardId _cardId;
        public CardsAddAttachmentRequest(Card cardId)
        {
            _cardId = cardId;
        }
    }

    public abstract class CardsRequest : TrelloClientRequest
    {
        protected override string LocalPath => "/1/cards";
    }
}
