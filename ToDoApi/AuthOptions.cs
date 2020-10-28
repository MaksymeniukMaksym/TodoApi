
using Microsoft.IdentityModel.Tokens;
using System.Text;
 
namespace ToDoApi
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; 
        public const string AUDIENCE = "localhost:4200";
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 1000;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}