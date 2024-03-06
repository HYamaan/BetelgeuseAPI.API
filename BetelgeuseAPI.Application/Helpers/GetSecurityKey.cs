using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BetelgeuseAPI.Application.Helpers
{
    public static class GetSecurityKey
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
