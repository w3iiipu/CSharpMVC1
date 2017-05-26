using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {
        public string Index(string name)
        {
            return "Hello World " + name;
            
        }
        public ActionResult Index1()
        {
            //ViewBag - Uses Dynamic properties - does not provide compile time error checking - stored as name/value pairs in ViewData dictionary
            ViewBag.Countries = new List<string>()
            {
                "USA", "Germany", "Singapore", "Canada"
            };

            //ViewData - Uses Keys - does not provide compile time error checking
            ViewData["Countries"] = new List<string>()
            {
                "USA", "Germany", "Singapore", "Canada"
            };

            return View();
        }

        /// <summary>
        /// This method returns the version of MVC
        /// </summary>
        /// <returns></returns>
        public string MVCVersion()
        {
            return typeof(Controller).Assembly.GetName().Version.ToString();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}