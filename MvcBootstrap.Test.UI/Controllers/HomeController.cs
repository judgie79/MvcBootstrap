using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBootstrap.Test.UI.Models;

namespace MvcBootstrap.Test.UI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
			return View(new TestModel()
				{
					Id = 1,
					Name = "Toller Name"
				});
        }

    }
}
