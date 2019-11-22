using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org.appstreams.Controllers
{
    public class APIController : Controller
    {
        [Route("/api")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/api/{service}")]
        public IActionResult Service(string service)
        {
            return View("~/views/api/" + service + "/index.cshtml");
        }

        [Route("/api/{service}/{api}")]
        public IActionResult Api(string service, string api)
        {
            string view = String.Concat("~/views/api/", service, "/", api, "/index.cshtml");
            return View(view);
        }
    }
}
