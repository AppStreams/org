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
    public class ServicesController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;


        public ServicesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

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

        [Route("/services/{service}/{api}")]
        public IActionResult Api(string service, string api)
        {
            return View(String.Concat("~/views/services/", service, "/", api, "/index.cshtml"));
        }
    }
}
