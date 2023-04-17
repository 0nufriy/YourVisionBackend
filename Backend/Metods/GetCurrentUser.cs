using Backend.Model;
using System.Security.Claims;

namespace Backend.Metods
{
    public class CurrentUser
    {
        public static UserFromJWT? Get(HttpContext httpContext)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;

            if (identity is not null)
            {
                var userClaims = identity.Claims;

                return new UserFromJWT
                {
                    Login = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                    ProfileId = Convert.ToInt32(userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Sid)?.Value),
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}
