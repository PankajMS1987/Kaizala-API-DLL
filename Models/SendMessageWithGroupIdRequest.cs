using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class SendMessageWithGroupIdRequest
    {
        public string GroupId { get; set; }
        public SendMessageRq SendMessageRequest { get; set; }
    }
}
