namespace Microsoft.Kaizala.Models
{
    using System.Collections.Generic;

    public class GetBotUsersResponse : ErrorDetails
    {
        public List<Bot> Bots { get; set; }
    }
}
