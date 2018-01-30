using GoMentor.Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Services
{
    public static class AuthService
    {
        public static ClaimsIdentity GetUserIdentity(this UserModel user)
        {
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            return identity;

        }

    }
}