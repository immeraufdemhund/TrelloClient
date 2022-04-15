using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TrelloClient.Internal;

namespace TrelloClient.Models
{
    public class Card
    {
        public CardId Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public bool Closed { get; set; }
        public string IdList { get; set; }
        public string IdBoard { get; set; }
        public DateTime? Due { get; set; }
        public List<Label> Labels { get; set; }
        public int IdShort { get; set; }
        // public CardBadges Badges { get; set; }
        // public List<Checklist> Checklists { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public double Pos { get; set; }
        public DateTime DateLastActivity { get; set; }
        public List<string> IdMembers { get; set; }
        // public IEnumerable<Color> LabelColors { get { return Labels == null ? Enumerable.Empty<Color>() : Labels.Select(l => l.Color); } }
    }
    public struct CardId
    {
        public static implicit operator string(CardId cardId) => cardId.Id;
        public static implicit operator CardId(Card card) => new CardId(card.Id);
        public static implicit operator CardId(string card) => new CardId(card);

        private string Id { get; }
        public CardId(string id)
        {
            Id = id;
            Guard.MatchesLongId(this);
        }
        public override string ToString() => this;
    }
    public struct CardShortId
    {
        public static implicit operator string(CardShortId cardId) => cardId.Id;
        public static implicit operator CardShortId(Card card) => new CardShortId(card.Id);
        public static implicit operator CardShortId(string card) => new CardShortId(card);

        private string Id { get; }
        public CardShortId(string id)
        {
            Id = id;
            // Guard.MatchesShortId(this);
        }
        public override string ToString() => this;
    }
}
