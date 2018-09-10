namespace Microsoft.Kaizala
{
    using Microsoft.Kaizala.Exceptions;
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Services;
    using Microsoft.Kaizala.Util;
    using System;

    /// <summary>
    /// Implements IKaizalaSession.
    /// </summary>
    public class KaizalaSession : IKaizalaSession
    {
        /// <summary>
        /// Maintains the Connector Application Id.
        /// </summary>
        private string ApplicationId;

        /// <summary>
        /// Maintains the Connector ApplicationSecret.
        /// </summary>
        private string ApplicationSecret;

        /// <summary>
        /// Maintains the Connector RefreshToken.
        /// </summary>
        private string RefreshToken;

        /// <summary>
        /// Maintains the ApiRoot.
        /// </summary>
        private string ApiRoot;

        /// <summary>
        /// Maintains the AccessToken.
        /// </summary>
        private string AccessToken;

        /// <summary>
        /// To make Bot Related API Calls.
        /// </summary>
        private IBotAPIStub BotUserAPI;
        public KaizalaSession(string appId, string appSecret, string refreshToken)
        {
            this.ApplicationId = appId;
            this.ApplicationSecret = appSecret;
            this.RefreshToken = refreshToken;
            this.GenerateAccessToken();
            BotUserAPI = new BotAPIStubImpl(this);
        }
        public string GenerateAccessToken()
        {
            GenerateAccessTokenRs accessTokenRs = AuthenticationService.GetAccessToken(ApplicationId, ApplicationSecret, RefreshToken);
            //Checking for Error response
            ValidateAccessTokenErrorResponse(accessTokenRs);
            this.AccessToken = accessTokenRs.AccessToken;
            this.ApiRoot = accessTokenRs.EndpointUrl;
            if(!String.IsNullOrEmpty(accessTokenRs.RefreshToken))
            {
                this.RefreshToken = accessTokenRs.RefreshToken;
            }
            return this.AccessToken;
        }

        public string GetAccessToken()
        {
            if(String.IsNullOrEmpty(this.AccessToken))
            {
                this.GenerateAccessToken();
            }
            return this.AccessToken;
        }
        public string GetRefreshToken()
        {
            return this.RefreshToken;
        }

        public IContentCreationAPIStub GetContentCreationAPIStub()
        {
            return new ContentCreationAPIStubImpl(this);
        }
        public string GetApiEndPoint()
        {
            return this.ApiRoot;
        }

        public GetBotUsersResponse GetBotUsers()
        {
            return BotUserAPI.GetBotUsers();
        }
        public CreateBotUserResponse CreateBotUser(CreateBotUserRequest botRequest)
        {
            return BotUserAPI.CreateBotUser(botRequest);
        }
        public ErrorDetails AddBotUserToGroup(string groupID, string botUserId)
        {
            return BotUserAPI.AddBotUserToGroup(groupID, new AddBotToGroupRequest(botUserId));
        }

        public ErrorDetails DeleteBotUser(string botUserId)
        {
            return BotUserAPI.DeleteBotUser(botUserId);
        }

        public ErrorDetails UpdateBotUser(string botUserId, CreateBotUserRequest botUserRequest)
        {
            return BotUserAPI.UpdateBotUser(botUserId, botUserRequest);
        }
        public BotUserSession GetBotUserSession(string botUserID)
        {
            //TODO: add caching and before creating check in cache
            return new BotUserSession(this, botUserID);
        }
        private void ValidateAccessTokenErrorResponse(GenerateAccessTokenRs accessTokenRs)
        {
            if (accessTokenRs.ErrorCode != null)
            {
                throw new AuthenticationException(accessTokenRs.ErrorCode, accessTokenRs.Message);
            }

        }

    }
}
