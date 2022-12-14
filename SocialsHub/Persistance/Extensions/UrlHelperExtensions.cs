using Microsoft.AspNetCore.Mvc;

namespace SocialsHub.Persistance.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string AbsoluteContent(this IUrlHelper url, string contentPath)
        {
            HttpRequest request = url.ActionContext.HttpContext.Request;
            return new Uri(new Uri(request.Scheme + "://" + request.Host.Value), url.Content(contentPath)).ToString();
        }
    }
}
