namespace Microsoft.Kaizala.Exceptions
{
    using Microsoft.Kaizala.Models;
    using Microsoft.Kaizala.Util;

    public class ErrorValidator
    {
        public static bool IsResponseValid(ErrorDetails response)
        {
            if(string.IsNullOrEmpty(response.ErrorCode))
            {
                return true;
            }
            return false;

        }
        public static bool IsAccessTokenExpired(ErrorDetails response)
        {
            if (!string.IsNullOrEmpty(response.ErrorCode))
            {
                if(response.ErrorCategoryKey.Contains(ErrorConstant.AUTH_EXCEPTION_STRING) && response.ErrorCode.Contains(ErrorConstant.INVALID_TOKEN_STRING) && response.Message.Contains(ErrorConstant.INVALID_TOKEN_MESSAGE_STRING))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
