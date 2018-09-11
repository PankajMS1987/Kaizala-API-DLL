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
        public string BotUserId { get; set; }
    }
}
