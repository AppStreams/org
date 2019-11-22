using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org.appstreams.Controllers
{
    public class EventsController : Controller
    {
        [Route("/events")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/events/{service}")]
        public IActionResult Service(string service)
        {
            return View("~/views/events/" + service + "/index.cshtml");
        }

        [Route("/events/{service}/{api}/{resource?}")]
        public IActionResult Api(string service, string api, string resource)
        {
            string view;
            if (resource == null)
                view = String.Concat("~/views/events/", service, "/" + api, "/index.cshtml");
            else
                view = String.Concat("~/views/events/", service, "/" + api + "/", resource, ".cshtml");

            return View(view);
        }
    }
}
