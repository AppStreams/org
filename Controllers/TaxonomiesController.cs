using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace org.appstreams.Controllers
{
    public class TaxonomiesController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public TaxonomiesController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/taxonomies")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/taxonomies/{service}")]
        public IActionResult Service(string service)
        {
            string webRootPath = _hostingEnvironment.ContentRootPath;
            string jfile = webRootPath + "/views/taxonomies/" + service + "/index.cshtml";

            if (System.IO.File.Exists(jfile))
                return View("~/views/taxonomies/" + service + "/index.cshtml");
            else
                return View("~/views/taxonomies/" + service + ".cshtml");
        }

        [Route("/taxonomies/{service}/{api}/{resource?}")]
        public IActionResult Api(string service, string api, string resource)
        {
            if (!String.IsNullOrWhiteSpace(resource))
            {
                string domainName = HttpContext.Request.Host.Value;
                ViewBag.Resource = String.Concat("http://", domainName, "/taxonomies/", service, "/", api, "/", resource);
                return View(String.Concat("~/views/taxonomies/view.cshtml"));
            }
            else
                return View(String.Concat("~/views/taxonomies/", service, "/", api, ".cshtml"));
        }
    }
}
