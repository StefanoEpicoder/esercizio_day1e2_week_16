using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class pagamentiController : Controller
    {
        // GET: pagamenti
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() //con il create mi vado a creare il form
        {
            return View();
        }
    }
}