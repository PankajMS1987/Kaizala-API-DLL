using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class CreateGroupRequest
    {
        public string Name { get; set; }
        public string WelcomeMessage { get; set; }
        public String [] Members { get; set; }
        public String [] MemberUserIds { get; set; }
        public String[] Admins { get; set; }
        public string GroupType { get; set; }
        public string GroupPhoto { get; set; }
        public string BackgroundPhoto { get; set; }
        public string ShortDescriptionString { get; set; }
        public string LongDescriptionString { get; set; }
    }
}
