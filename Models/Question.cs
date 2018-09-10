using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class Question
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public List<Option> Options { get; set; }
    }
}
