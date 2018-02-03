using Microsoft.AspNetCore.Http;

namespace QueryMiddleware.Extensions
{
    /// <summary>
    /// Extension methods on HttpContext to wrap things in code to make them bulletproof
    /// </summary>
    public static class HttpContextExtensions
    {
        public static string GetQueryMessage(this HttpContext context)
        {
            return context.Items[QueryStringNames.Message] as string;
        }

        public static void SetQueryMessage(this HttpContext context, string message)
        {
            context.Items[QueryStringNames.Message] = message;
        }
    }
}
