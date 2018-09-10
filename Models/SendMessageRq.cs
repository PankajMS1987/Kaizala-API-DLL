using System.Collections.Generic;

namespace Microsoft.Kaizala.Models
{
    public class SendMessageRq
    {
        public string Message { get; set; }
        public List<string> Subscribers { get; set; }
        public bool SendToAllSubscribers { get; set; }
    }
}
