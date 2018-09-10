namespace Microsoft.Kaizala.Models
{
    public class CreateGroupResponse : ErrorDetails
    {
        public string groupName { get; set; }
        public string groupId { get; set; }
        public bool membersAdded { get; set; }
    }
}
