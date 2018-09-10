namespace Microsoft.Kaizala.Models
{
    public class AddBotToGroupRequest
    {
        public AddBotToGroupRequest()
        {

        }
        public AddBotToGroupRequest(string botUserId)
        {
            this.BotUserId = botUserId;
        }
        string BotUserId { get; set; }
    }
}
