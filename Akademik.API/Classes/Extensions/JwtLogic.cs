using Akademik.API.Classes.Constants;

namespace Akademik.API.Classes.Extensions
{
    public static class JwtLogic
    {
        public static bool CheckIsValidJwtParameter(this string raw)
        {
            return raw.ToLower().StartsWith(JwtConstants.TokenMustStart.ToLower());
        }
    }
}