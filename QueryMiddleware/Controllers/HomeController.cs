using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QueryMiddleware.Extensions;
using QueryMiddleware.Models;
using QueryMiddleware.Settings;

namespace QueryMiddleware.Controllers
{
    /// <summary>
    /// Home controller
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly MessageSettings messageSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<MessageSettings> messageSettings)
        {
            this.logger = logger;
            this.messageSettings = messageSettings.Value;
        }

        public IActionResult Index()
        {
            string queryMessage = HttpContext.GetQueryMessage();

            // Do we have a message?
            if (queryMessage == default(string))
            {
                // Log this
                logger.LogInformation("No query message!");

                return View(new QueryMessageViewModel
                {
                    Message = messageSettings.NotFoundMessage
                });
            }

            // Log this
            logger.LogInformation("There is a query message");

            // Yes we do, so use it
            return View(new QueryMessageViewModel
            {
                Message = $"{messageSettings.FoundMessage}{queryMessage}"
            });
        }
    }
}
