namespace Microsoft.Kaizala.Util
{
    using Microsoft.Kaizala.Models;
    using System.Collections.Specialized;
 
    public class AuthenticationService
    {
        public static GenerateAccessTokenRs GetAccessToken(string appID, string appSecret, string refreshToken)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.APPLICATION_ID_STRING, appID);
            header.Add(Constants.APPLICATION_SECRET_STRING, appSecret);
            header.Add(Constants.REFRESH_TOKEN_STRING, refreshToken);

            GenerateAccessTokenRs response = AsyncHelpers.RunSync<GenerateAccessTokenRs> (()=> APICallHandler.GetAsync<GenerateAccessTokenRs>(header, string.Format(Constants.ACCESS_TOKEN_URL, Constants.API_ROOT)));
            return response;
        }
    }
}
