using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.Entities;

namespace api.Extensions
{
    public static class Claims
    {
        //This won't work if the user is not authenticated will give an error, sinc name or the Nameidentifier will always be null or empty
        public static string GetUserName(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name);
        }

        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if(Guid.TryParse(userId, out Guid id)){
                return id;
            }
            return null;

        }
    }
}