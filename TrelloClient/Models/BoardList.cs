using TrelloClient.Internal;

namespace TrelloClient.Models
{
    public class BoardList
    {
        public BoardListId Id { get; set; }
    }

    public struct BoardListId
    {
        public static implicit operator string(BoardListId cardId) => cardId.Id;
        public static implicit operator BoardListId(BoardList card) => new BoardListId(card.Id);
        public static implicit operator BoardListId(string card) => new BoardListId(card);

        private string Id { get; }
        public BoardListId(string id)
        {
            Id = id;
            Guard.MatchesLongId(this);
        }
        public override string ToString() => this;
    }
}
