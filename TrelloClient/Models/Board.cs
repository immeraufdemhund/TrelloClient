using System;
using TrelloClient.Internal;

namespace TrelloClient.Models
{
    public class Board
    {
        public BoardId Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        /// <summary>  came back as a JObject not a JValue </summary>
        public object DescData { get; set; }
        public bool Closed { get; set; }
        public string IdMemberCreator { get; set; }
        public string IdOrganization { get; set; }
        public bool Pinned { get; set; }
        public string Url { get; set; }
        public string ShortUrl { get; set; }
        public PrefsModel Prefs { get; set; }
        public object LabelNames { get; set; }
        public object Limits { get; set; }
        public bool Starred { get; set; }
        /// <summary>  this comes back as an object array </summary>
        public object Memberships { get; set; }
        public string ShortLink { get; set; }
        public bool Subscribed { get; set; }
        public object PowerUps { get; set; }
        /// <summary> format: date</summary>
        public DateTime DateLastActivity { get; set; }
        /// <summary> format: date</summary>
        public DateTime DateLastView { get; set; }
        public object IdTags { get; set; }
        /// <summary> Nullable format: date</summary>
        public DateTime? DatePluginDisable { get; set; }
        /// <summary> Nullable </summary>
        public string CreationMethod { get; set; }
        public int? IxUpdate { get; set; }
        /// <summary> Nullable </summary>
        public string TemplateGallery { get; set; }
        public bool EnterpriseOwned { get; set; }
        public class PrefsModel
        {
            /// <summary> valid values: org, board </summary>
            public string PermissionLevel { get; set; }
            public bool HideVotes { get; set; }
            /// <summary> valid values: disabled, enabled </summary>
            public string Voting { get; set; }
            public string Comments { get; set; }
            /// <summary> came back as string "members" documentation said it can be anything </summary>
            public object Invitations { get; set; }
            public bool SelfJoin { get; set; }
            public bool CardCovers { get; set; }
            public bool IsTemplate { get; set; }
            /// <summary> Valid values: pirate, regular </summary>
            public string CardAging { get; set; }
            public bool CalendarFeedEnabled { get; set; }
            /// <summary>  Pattern: ^[0-9a-fA-F]{24}$ </summary>
            public string Background { get; set; }
            public string BackgroundImage { get; set; }
            // public ImageDescriptor[] BackgroundImageScaled { get; set; }
            public bool BackgroundTile { get; set; }
            public string BackgroundBrightness { get; set; }
            public string BackgroundBottomColor { get; set; }
            public string BackgroundTopColor { get; set; }
            public bool CanBePublic { get; set; }
            public bool CanBeEnterprise { get; set; }
            public bool CanBeOrg { get; set; }
            public bool CanBePrivate { get; set; }
            public bool CanInvite { get; set; }
        }
    }

    public struct BoardId
    {
        public static implicit operator string(BoardId boardId) => boardId.Id;
        public static implicit operator BoardId(Board board) => new BoardId(board.Id);
        public static implicit operator BoardId(string card) => new BoardId(card);

        private string Id { get; }
        public BoardId(string id)
        {
            Id = id;
            Guard.MatchesLongId(this);
        }
        public override string ToString() => this;
    }

    public struct BoardShortId
    {
        public static implicit operator string(BoardShortId boardId) => boardId.Id;
        public static implicit operator BoardShortId(Board board) => new BoardShortId(board.Id);
        public static implicit operator BoardShortId(string card) => new BoardShortId(card);

        private string Id { get; }
        public BoardShortId(string id)
        {
            Id = id;
            Guard.MatchesShortId(this);
        }
        public override string ToString() => this;
    }
}
