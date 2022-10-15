using System.Security.Claims;

namespace SocialsHub.Persistance.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static string GetUserName(this ClaimsPrincipal model)
        {
            return model.FindFirstValue(ClaimTypes.Name);
        }


    }
}
