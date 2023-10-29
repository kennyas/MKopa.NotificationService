using Microsoft.AspNetCore.Mvc;
using SmsCore.Interface;
using SmsDomain.Domain;
using SMSNotificationService.Models;
using System.Diagnostics;

namespace SMSNotificationService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMessagePublisher publisher;

        public HomeController(ILogger<HomeController> logger, IMessagePublisher publisher)
        {
            _logger = logger;
            this.publisher = publisher;
        }

        public IActionResult Index()
        {
            publisher.Publish(new SmsNotificationRequestMessage
            {
                ClientRequestId = Guid.NewGuid().ToString(),
                MessageBody = "I come",
                PhoneNumber = "+2348067866755"
            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}