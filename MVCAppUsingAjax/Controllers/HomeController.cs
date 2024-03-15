using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVCAppUsingAjax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public string GetScore()
        {
            string physicalPath = Server.MapPath("~/Matches/Score.xml");
            var doc = XElement.Load(physicalPath);
            string score = doc.Element("Score").Value;
            return score;
        }
    }
}