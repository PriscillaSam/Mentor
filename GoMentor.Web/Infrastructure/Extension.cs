using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace GoMentor.Web.Infrastructure
{
    public static class Extension
    {
        public static UserModel GetUserIdentity(this IIdentity identity)
        {
            if(identity == null)
            {
                return null;
            }

            var userId = int.Parse(identity.GetClaimValue(ClaimTypes.NameIdentifier));
            var email = identity.GetClaimValue(ClaimTypes.Name);
            var role = identity.GetClaimValue(ClaimTypes.Role);
            var firstName = identity.GetClaimValue(ClaimTypes.GivenName);
            var lastName = identity.GetClaimValue(ClaimTypes.Surname);

            return new UserModel
            {
                UserId = userId,
                Email = email,
                Role = role,
                FirstName = firstName,
                LastName = lastName
            };
        }


        public static string GetClaimValue(this IIdentity identity, string claimType)
        {
            var claims = identity as ClaimsIdentity;
            if (claims == null)
            {
                return null;
            }
            var value = claims.FindFirst(claimType)?.Value;
            return value ?? String.Empty;
        }
    }
}