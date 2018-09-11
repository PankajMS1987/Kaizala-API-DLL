namespace Microsoft.Kaizala.Models
{
    public class SendMessageResponse : ErrorDetails
    {
        public string ReferenceId { get; set; }
        public FailedResult[] FailedResult { get; set; }
    }
}
