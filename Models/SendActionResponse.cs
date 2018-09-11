namespace Microsoft.Kaizala.Models
{
    public class SendActionResponse : ErrorDetails
    {
        public string ReferenceId { get; set; }
        public string ActionId { get; set; }
        public FailedResult[] FailedResult { get; set; }
    }
}
