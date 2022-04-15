using System;
using System.Collections.Generic;
using System.Net.Http;
using TrelloClient.Models;

namespace TrelloClient.Requests.Boards
{
    public abstract class BoardsRequest : TrelloClientRequest
    {
        protected override string LocalPath => "/1/boards";
    }

    public class GetIndividualBoardRequest : BoardsRequest
    {
        /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#actions-nested-resource">here</a>. </summary>
        public ActionsNestedResource Actions { get; }
        /// <summary> This is a nested resource. Read more about cards as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#cards-nested-resource">here.</a> </summary>
        public CardsNestedResource Cards { get; }
        /// <summary> Use with the cards param to include card pluginData with the response </summary>
        public bool CardPluginData { set => SetQueryParameter("card_pluginData", value); }
        /// <summary> This is a nested resource. Read more about check lists as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#checklists-nested-resource">here</a>. </summary>
        public CheckListsNestedResource CheckLists { get; }
        /// <summary> This is a nested resource. Read more about labels as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#labels-nested-resource">here</a>. </summary>
        public LabelsNestedResource Labels { get; }
        /// <summary> This is a nested resource. Read more about custom fields as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#custom-fields-nested-resource">here</a>. </summary>
        public CustomFieldsNestedResource CustomFields { get; }
        /// <summary> This is a nested resource. Read more about lists as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#lists-nested-resource">here</a>. </summary>
        public ListsNestedResource Lists { get; }
        /// <summary> This is a nested resource. Read more about members as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#members-nested-resource">here</a>. </summary>
        public MembersNestedResource Members { get; }
        public MembershipsNestedResource Memberships { get; }
        public OrganizationNestedResource Organization { get; }
        public bool OrganizationPluginData {set => SetQueryParameter("organization_pluginData", value);}
        /// <summary>
        /// The fields of the board to be included in the response. Valid values: all or a comma-separated list of: closed, dateLastActivity, dateLastView, desc, descData, idMemberCreator, idOrganization, invitations, invited, labelNames, memberships, name, pinned, powerUps, prefs, shortLink, shortUrl, starred, subscribed, url
        /// Default: name,desc,descData,closed,idOrganization,pinned,url,shortUrl,prefs,labelNames
        /// </summary>
        public string[] Fields {set => SetQueryParameter("fields", string.Join(",", value));}

        public bool ReturnPluginData {set => SetQueryParameter("pluginData", value);}
        public bool MyPrefs {set => SetQueryParameter("myPrefs", value);}
        public bool Tags {set => SetQueryParameter("tags", value);}

        public bool GetMyBoardStars { set => ConditionalSetQueryParameter("boardStars", "mine", value); }
        public bool GetNoneBoardStars { set => ConditionalSetQueryParameter("boardStars", "none", value); }
        protected override string LocalPath => base.LocalPath + $"/{_boardsId}";
        protected override HttpMethod HttpMethod => HttpMethod.Get;

        private readonly string _boardsId;

        public GetIndividualBoardRequest(Board boardsId) : this()
        {
            _boardsId = boardsId.Id;
        }

        public GetIndividualBoardRequest(string shortId) : this()
        {
            _boardsId = shortId;
        }

        private GetIndividualBoardRequest()
        {
            Actions =  new ActionsNestedResource(SetQueryParameter);
            Cards = new CardsNestedResource(SetQueryParameter);
            CheckLists = new CheckListsNestedResource(SetQueryParameter);
            CustomFields = new CustomFieldsNestedResource(SetQueryParameter);
            Labels = new LabelsNestedResource(SetQueryParameter);
            Lists = new ListsNestedResource(SetQueryParameter);
            Members = new MembersNestedResource(SetQueryParameter);
            Memberships = new MembershipsNestedResource(SetQueryParameter);
            Organization = new OrganizationNestedResource(SetQueryParameter);
        }
    }

    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#cards-nested-resource">here</a>. </summary>
    public class CardsNestedResource : NestedResource
    {
        public bool GetAllCards {set => ConditionalSetQueryParameter("cards", "all", value);}
        public bool GetOpenCards {set => ConditionalSetQueryParameter("cards", "open", value);}
        public bool GetClosedCards {set => ConditionalSetQueryParameter("cards", "closed", value);}
        public bool GetVisibleCards {set => ConditionalSetQueryParameter("cards", "visible", value);}
        public bool DoNotReturnCards {set => ConditionalSetQueryParameter("cards", "none", value);}
        public string[] CardFields {set => SetQueryParameter("card_fields", string.Join(",", value));}

        public bool ReturnCardMembers {set => ConditionalSetQueryParameter("card_members", "true", value);}
        public string[] CardMemberFields {set => SetQueryParameter("card_member_fields", string.Join(",", value));}

        public bool ReturnCardAttachments {set => ConditionalSetQueryParameter("card_attachments", "true", value);}
        public string[] CardAttachmentFields {set => SetQueryParameter("card_attachment_fields", string.Join(",", value));}

        public bool ReturnCardStickers {set => ConditionalSetQueryParameter("card_stickers", "true", value);}

        public CardsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#checklists-nested-resource">here</a>. </summary>
    public class CheckListsNestedResource : NestedResource
    {
        public CheckListsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }

    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#labels-nested-resource">here</a>. </summary>
    public class LabelsNestedResource : NestedResource
    {
        public LabelsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#custom-fields-nested-resource">here</a>. </summary>
    public class CustomFieldsNestedResource : NestedResource
    {
        public CustomFieldsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#lists-nested-resource">here</a>. </summary>
    public class ListsNestedResource : NestedResource
    {
        public bool GetAllLists {set => ConditionalSetQueryParameter("lists", "all", value);}
        public bool GetOpenLists {set => ConditionalSetQueryParameter("lists", "open", value);}
        public bool GetClosedLists {set => ConditionalSetQueryParameter("lists", "closed", value);}
        public bool DoNotReturnLists {set => ConditionalSetQueryParameter("lists", "none", value);}
        public string[] ListFields {set => SetQueryParameter("list_fields", string.Join(",", value));}

        public ListsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#members-nested-resource">here</a>. </summary>
    public class MembersNestedResource : NestedResource
    {
        public MembersNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="">here</a>. </summary>
    public class MembershipsNestedResource : NestedResource
    {
        public MembershipsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="">here</a>. </summary>
    public class OrganizationNestedResource : NestedResource
    {
        public OrganizationNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/#actions-nested-resource">here</a>. </summary>
    public class ActionsNestedResource : NestedResource
    {
        public ActionsNestedResource(Action<string, string> addAction) : base(addAction)
        {
        }
    }
    /// <summary> This is a nested resource. Read more about actions as nested resources <a href="https://developer.atlassian.com/cloud/trello/guides/rest-api/nested-resources/">here</a>. </summary>
    public abstract class NestedResource
    {
        private readonly Action<string, string> _addAction;

        protected NestedResource(Action<string, string> addAction)
        {
            _addAction = addAction;
        }
        protected void SetQueryParameter(string key, object value)
        {
            _addAction(key, value.ToString());
        }
        protected void ConditionalSetQueryParameter(string key, object value, bool condition)
        {
            if(condition) SetQueryParameter(key, value);
        }
    }
}
