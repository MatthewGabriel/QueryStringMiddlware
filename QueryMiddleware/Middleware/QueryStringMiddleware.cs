using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using QueryMiddleware.Extensions;
using System;
using System.Threading.Tasks;

namespace QueryMiddleware.Middleware
{
    public class QueryStringMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<QueryStringMiddleware> logger;

        public QueryStringMiddleware(RequestDelegate next, ILogger<QueryStringMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log this
            logger.LogInformation("On the way in");

            // Yes, so try to the message from the query string
            string queryMessage = context.Request.Query[QueryStringNames.Message];

            // Did we get one?
            if (!String.IsNullOrEmpty(queryMessage))
            {
                // Yes, we got one, so set it into httpcontext using our extension method to make it simple
                context.SetQueryMessage(queryMessage);
            }

            // Run other middleware
            await next.Invoke(context);

            // Log this
            logger.LogInformation("On the way out");
        }
    }
}
