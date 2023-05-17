using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication3LearningBusinessObjects.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            ViewData["Countries"] = new List<string>() { "Hari","Pari" };
            return View();
        }



    }
}