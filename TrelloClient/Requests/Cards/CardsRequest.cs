namespace TrelloClient.Requests.Cards
{
    public abstract class CardsRequest : TrelloClientRequest
    {
        protected override string LocalPath => "/1/cards";
    }
}
