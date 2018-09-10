namespace Microsoft.Kaizala.Services
{
    using Microsoft.Kaizala.Models;

    public interface IBotAPIStub
    {
        CreateBotUserResponse CreateBotUser(CreateBotUserRequest botUserRequest);
        ErrorDetails UpdateBotUser(string botUserId, CreateBotUserRequest botUserRequest);
        ErrorDetails DeleteBotUser(string botUserId);
        ErrorDetails AddBotUserToGroup(string groupId, AddBotToGroupRequest addBotToGroupRequest);
        GetBotUsersResponse GetBotUsers();
        BotAccessTokenResponse GenerateAccessToken(string botUserId);
        void SetKaizalaSession(IKaizalaSession session);
        string GetAccessToken();
    }
}
