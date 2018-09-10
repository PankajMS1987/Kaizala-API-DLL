namespace Microsoft.Kaizala.Models
{
    public class BotAccessTokenResponse : ErrorDetails
    {
        public string accessToken { get; set; }
        public long accessTokenExpiry { get; set; }
        public string scope { get; set; }
    }
}
