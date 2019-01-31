using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteAttributesApp.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        [Route("Account")]
        public ActionResult Index() // Home/Index
        {
            return View();
        }
        //2/name
        [Route("{id:int}/{name=volga}")]
        public string Test(int id, string name) => $"{id.ToString()}. {name}";

        [Route("~/lol/twit/{id:int}")] // ~ - избегаем префикса 'Home'
        public string Twit(int id) => id.ToString();

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