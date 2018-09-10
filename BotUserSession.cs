namespace Microsoft.Kaizala
{
    using Microsoft.Kaizala.Exceptions;
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Services;

    public class BotUserSession : IKaizalaSession
    {
        private IBotAPIStub BotAPIStub;
        private IKaizalaSession KaizalaSession;
        private string BotUserId;
        private string AccessToken;

        public BotUserSession(IKaizalaSession session, string botUserId)
        {
            this.KaizalaSession = session;
            this.BotUserId = botUserId;
            BotAPIStub = new BotAPIStubImpl(session);
        }
        public string GenerateAccessToken()
        {
            BotAccessTokenResponse response = BotAPIStub.GenerateAccessToken(this.BotUserId);
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                this.KaizalaSession.GenerateAccessToken();
                response = BotAPIStub.GenerateAccessToken(this.BotUserId);
                if(!ErrorValidator.IsResponseValid(response))
                {
                    //TODO : throw exception
                }
            }
            this.AccessToken = response.accessToken;
            return this.AccessToken;

        }

        public string GetAccessToken()
        {
            return this.AccessToken;
        }

        public string GetApiEndPoint()
        {
            throw new System.NotImplementedException();
        }
        public IContentCreationAPIStub GetContentCreationAPIStub()
        {
            return new ContentCreationAPIStubImpl(this);
        }

    }
}
