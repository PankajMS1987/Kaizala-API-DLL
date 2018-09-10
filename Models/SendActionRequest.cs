namespace Microsoft.Kaizala.Models
{
    using System.Collections.Generic;

    public class SendActionRequest
    {
        public string ActionType { get; set; }
        public IActionBody ActionBody { get; set; }
        public List<string> Subscribers { get; set; }
        public bool SendToAllSubscribers { get; set; }

    }
}
