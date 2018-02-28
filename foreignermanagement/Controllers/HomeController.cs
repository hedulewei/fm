using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using foreignermanagement.Models;

namespace foreignermanagement.Controllers
{
    public class HomeController : Controller
    {
        public string demo()
        {
            var ret = "no result";
            using(var db=new dbmodel.fmContext())
            {
               var demo= db.Foreigner.FirstOrDefault();
                if (demo != null)
                {
                    ret = demo.Hisorg;
                }
            }
            return ret;
        }

        public IActionResult Index()
        {
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
