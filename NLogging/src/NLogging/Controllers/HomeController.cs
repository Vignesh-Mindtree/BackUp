using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using NLog.Config;
using NLog;
using NLog.Fluent;
using Microsoft.Extensions.Logging;

namespace NLogging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private const string LoggerName = "HomeController";
        private string hostName = null;
        private System.Net.IPHostEntry hostAddress = null;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

           // hostName = System.Net.Dns.GetHostName();
            //hostAddress = System.Net.Dns.GetHostEntry(hostName);   
        }
        public IActionResult Index()
        {
            //logger.Log(NLog.LogLevel.Trace,DateTime.Now.ToString());
            //logger.Log(NLog.LogLevel.Trace,"Host Name : " + hostName);
            //logger.LogInformation(hostAddress.AddressList[1].ToString());
            try
            {
                _logger.LogInformation("Index Method Entered1");
                _logger.LogInformation("Index Method Entered2");
                _logger.LogInformation("Index Method Entered3");
                _logger.LogInformation("Index Method Entered4");

                //_logger.Log(LogLevel.Critical,)
                throw new NotImplementedException();
                

            }
            catch(Exception ex)
            {
                _logger.LogError("Exception {0} thrown at {1}", ex.Message, ex.StackTrace);
            }

            return View();
         
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
