using System;
using TrelloClient.Internal;

namespace TrelloClient.Models
{
    public class Attachment
    {
        public AttachmentId Id { get; set; }
        public string Bytes { get; set; }
        public DateTime Date { get; set; }
        public string EdgeColor { get; set; }
        public string IdMember { get; set; }
        public bool IsUpload { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public string[] Previews { get; set; }
        public string Url { get; set; }
        public float Pos { get; set; }
    }
    public struct AttachmentId
    {
        public static implicit operator string(AttachmentId cardId) => cardId.Id;
        public static implicit operator AttachmentId(Attachment card) => new AttachmentId(card.Id);
        public static implicit operator AttachmentId(string card) => new AttachmentId(card);

        private string Id { get; }
        public AttachmentId(string id)
        {
            Id = id;
            Guard.MatchesLongId(this);
        }
        public override string ToString() => this;
    }
}
