using System.Net.Http;
using TrelloClient.Models;

namespace TrelloClient.Requests.Cards
{
    public class GetCard : CardsRequest
    {
        private readonly string _idCard;

        public GetCard(CardShortId id)
        {
            _idCard = id;
        }
        public GetCard(Card id)
        {
            _idCard = id.Id;
        }

        protected override HttpMethod HttpMethod => HttpMethod.Get;
        protected override string LocalPath => base.LocalPath + $"/{_idCard}";
    }
}
