using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BLL.JWT
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer";
        public const string AUDIENCE = "AuthClient";
        const string KEY = "you_are_not_supposed_to_kno_this_KEY_101";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
