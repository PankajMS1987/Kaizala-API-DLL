using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class SendMessageResponse : ErrorDetails
    {
        public string referenceId { get; set; }
    }
}
