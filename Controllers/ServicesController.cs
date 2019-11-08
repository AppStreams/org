using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org.appstreams.Controllers
{
    public class ServicesController : Controller
    {
        [Route("/services")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/services/{service}")]
        public IActionResult Service(string service)
        {
            return View("~/views/services/" + service + "/index.cshtml");
        }

        [Route("/services/{service}/{api}/{resource?}")]
        public IActionResult Api(string service, string api, string resource)
        {
            // /services/waste/collection/Request
            // /services/waste/collection/Response

            string view;
            if (resource == null)
                view = String.Concat("~/views/services/", service, "/", api, "/index.cshtml");
            else
                view = String.Concat("~/views/services/", service, "/", api, "/", resource, ".cshtml");

            return View(view);
        }
    }
}
