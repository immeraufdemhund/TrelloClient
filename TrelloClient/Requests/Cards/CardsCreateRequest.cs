using System.Net.Http;
using TrelloClient.Internal;
using TrelloClient.Models;

namespace TrelloClient.Requests.Cards
{
    public class CardsCreateRequest : CardsRequest
    {
        protected override HttpMethod HttpMethod => HttpMethod.Post;
        public string Name { set => SetQueryParameter("name", value); }
        /// <summary>If using idCardSource you can specify which properties to copy over. all or comma-separated list of: attachments,checklists,customFields,comments,due,labels,members,start,stickers</summary>
        public string KeepFromSource { set => SetQueryParameter("keepFromSource", value); }
        public string Description { set => SetQueryParameter("desc", value); }
        public bool SetPositionTop { set => SetQueryParameter("pos", "top"); }
        public bool SetPositionBottom { set => SetQueryParameter("pos", "bottom"); }
        /// <summary>Comma-separated list of member IDs to add to the card</summary>
        public string[] Members {set => SetQueryParameter("idMembers", string.Join(",", value)); }
        public uint Order { set => SetQueryParameter("pos", value.ToString()); }
        public string Labels { set => SetQueryParameter("idLabels", value); }
        public Card IdCardSource
        {
            set
            {
                Guard.MatchesLongId(value.Id, "CardSourceId");
                SetQueryParameter("idCardSource", value.Id);
            }
        }

        public CardsCreateRequest(BoardList boardList)
        {
            SetQueryParameter("idList", boardList.Id);
        }
    }
}
