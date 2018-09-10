using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Kaizala.Models
{
    public class SurveyActionBody : IActionBody
    {
        public bool IsAnonymous { get; set; }
        public bool IsSenderOnly { get; set; }
        public bool AcceptMultipleResponses { get; set; }
        public int DueDate { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }
}
