namespace Microsoft.Kaizala
{
    public interface IKaizalaSession
    {
        string GetAccessToken();
        string GenerateAccessToken();
        string GetApiEndPoint();


    }
}
