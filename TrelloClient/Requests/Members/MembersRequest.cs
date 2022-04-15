using System.Net.Http;

namespace TrelloClient.Requests.Members
{
    public class MembersRequest : TrelloClientRequest
    {
        protected override string LocalPath => $"/1/members/{_memberIdOrName}";
        protected override HttpMethod HttpMethod => HttpMethod.Get;

        private readonly string _memberIdOrName;

        public MembersRequest(string memberIdOrName)
        {
            _memberIdOrName = memberIdOrName;
        }
    }
}