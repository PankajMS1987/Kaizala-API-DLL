namespace Microsoft.Kaizala.Util
{
    /// <summary>
    /// Keeping all the api related path and other constants
    /// </summary>
    class Constants
    {
        public const string ACCESS_TOKEN_STRING = "accessToken";
        public const string APPLICATION_ID_STRING = "applicationId";
        public const string APPLICATION_SECRET_STRING = "applicationSecret";
        public const string REFRESH_TOKEN_STRING = "refreshToken";
        public const string API_ROOT = "https://api.kaiza.la";
        public const string ACCESS_TOKEN_URL = "{0}/v1/accessToken";
        public const string SEND_MESSAGE_IN_GROUP_URL = "{0}/v1/groups/{1}/messages";
        public const string SEND_ACTION_IN_GROUP_URL = "{0}/v1/groups/{1}/actions";
        public const string CREATE_GROUP_URL = "{0}/v1/groups";
        public const string CREATE_BOT_USER_URL = "{0}/v1/bot";
        public const string UPDATE_BOT_USER_URL = "{0}/v1/bot/{1}";
        public const string GENERATE_BOT_ACCESS_TOKEN = "{0}/v1/bot/accessToken/{1}";
        public const string ADD_BOT_TO_GROUP_URL = "{0}/v1/groups/{1}/bot";
        public const int MAX_SUBSCRIBER_COUNT = 30;
    }
}
