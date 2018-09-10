namespace Microsoft.Kaizala.Services
{
    using Microsoft.Kaizala.Exceptions;
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Util;
    using Newtonsoft.Json;
    using System.Collections.Specialized;

    /// <summary>
    /// Implements the BotAPIStub.
    /// </summary>
    public class BotAPIStubImpl : IBotAPIStub
    {
        private IKaizalaSession session;
        public BotAPIStubImpl(IKaizalaSession session)
        {
            this.session = session;
        }
        /// <summary>
        /// Add Bot User to Group.
        /// </summary>
        /// <param name="accessToken">The AccessToken.</param>
        /// <param name="groupId">The Group Id.</param>
        /// <param name="addBotToGroupRequest">The AddBotToGroupRequest.</param>
        public ErrorDetails AddBotUserToGroup(string groupId, AddBotToGroupRequest addBotToGroupRequest)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            string request = JsonConvert.SerializeObject(addBotToGroupRequest);
            CreateBotUserResponse response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PostAsync<CreateBotUserResponse>(header, string.Format(Constants.ADD_BOT_TO_GROUP_URL, Constants.API_ROOT, groupId), request));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PostAsync<CreateBotUserResponse>(header, string.Format(Constants.ADD_BOT_TO_GROUP_URL, Constants.API_ROOT, groupId), request));
            }
            return response;
        }

        public CreateBotUserResponse CreateBotUser(CreateBotUserRequest botUserRequest)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            string request = JsonConvert.SerializeObject(botUserRequest);
            CreateBotUserResponse response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PostAsync<CreateBotUserResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT), request));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PostAsync<CreateBotUserResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT), request));
            }

            return response;
        }

        public ErrorDetails DeleteBotUser(string botUserId)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            CreateBotUserResponse response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.DeleteAsync<CreateBotUserResponse>(header, string.Format(Constants.UPDATE_BOT_USER_URL, Constants.API_ROOT)));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.DeleteAsync<CreateBotUserResponse>(header, string.Format(Constants.UPDATE_BOT_USER_URL, Constants.API_ROOT)));
            }

            return response;
        }

        public BotAccessTokenResponse GenerateAccessToken(string botUserId)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            BotAccessTokenResponse response = AsyncHelpers.RunSync<BotAccessTokenResponse>(() => APICallHandler.GetAsync<BotAccessTokenResponse>(header, string.Format(Constants.GENERATE_BOT_ACCESS_TOKEN, Constants.API_ROOT, botUserId)));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<BotAccessTokenResponse>(() => APICallHandler.GetAsync<BotAccessTokenResponse>(header, string.Format(Constants.GENERATE_BOT_ACCESS_TOKEN, Constants.API_ROOT, botUserId)));
            }

            return response;
        }

        public string GetAccessToken()
        {
            throw new System.NotImplementedException();
        }

        public GetBotUsersResponse GetBotUsers()
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            GetBotUsersResponse response = AsyncHelpers.RunSync<GetBotUsersResponse>(() => APICallHandler.GetAsync<GetBotUsersResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT)));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<GetBotUsersResponse>(() => APICallHandler.GetAsync<GetBotUsersResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT)));
            }

            return response;
        }

        public void SetKaizalaSession(IKaizalaSession session)
        {
            this.session = session;
        }

        public ErrorDetails UpdateBotUser(string botUserId, CreateBotUserRequest botUserRequest)
        {
            //preparing header
            NameValueCollection header = new NameValueCollection();
            header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GetAccessToken());
            string request = JsonConvert.SerializeObject(botUserRequest);
            CreateBotUserResponse response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PutAsync<CreateBotUserResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT), request));
            if (!ErrorValidator.IsResponseValid(response) && ErrorValidator.IsAccessTokenExpired(response))
            {
                header.Remove(Constants.ACCESS_TOKEN_STRING);
                header.Add(Constants.ACCESS_TOKEN_STRING, this.session.GenerateAccessToken());
                response = AsyncHelpers.RunSync<CreateBotUserResponse>(() => APICallHandler.PutAsync<CreateBotUserResponse>(header, string.Format(Constants.CREATE_BOT_USER_URL, Constants.API_ROOT), request));
            }

            return response;
        }
    }
}
