using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace api.Extentions
{
    public static class ClaimsExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")).Value;
            // O PROBLEMA é que a URL tinha que ser "emailaddress" e não "email"...o cara me fez pensar que o nome era o mesmo do que estava no TOKENSERVICE
        }
    }
}