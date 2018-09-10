namespace Microsoft.Kaizala.Models
{
    using System.Collections.Generic;

    public class AnnouncementActionBody : IActionBody
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public List<string> MediaResources { get; set; }
    }
}
