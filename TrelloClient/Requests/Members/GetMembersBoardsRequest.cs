namespace TrelloClient.Requests.Members
{
    public class GetMembersBoardsRequest : MembersRequest
    {
        protected override string LocalPath => base.LocalPath + "/boards";

        public GetMembersBoardsRequest(string memberIdOrName)
            : base(memberIdOrName)
        {
        }
    }
}