namespace Akademik.API.Classes
{
    public interface ITokenHandler
    {
        bool SetToken(string token);
        string GetToken();
    }
}