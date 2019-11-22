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
    public class ModelsController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ModelsController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("/models")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/models/{service}")]
        public IActionResult Service(string service)
        {
            // get the json if we have one
            string webRootPath = _hostingEnvironment.ContentRootPath;
            string jfile = webRootPath + "/metadata/models/" + service + ".json";
            if (System.IO.File.Exists(jfile))
            {
                using (StreamReader r = new StreamReader(jfile))
                {
                    ViewBag.Json = r.ReadToEnd();
                }
            }

            string jfileSample = webRootPath + "/metadata/models/" + service + "-sample.json";
            if (System.IO.File.Exists(jfileSample))
            {
                using (StreamReader r = new StreamReader(jfileSample))
                {
                    ViewBag.JsonSample = r.ReadToEnd();
                }
            }

            return View("~/views/models/" + service + "/index.cshtml");
        }

        [Route("/models/{service?}/{model}/{resource?}")]
        public IActionResult Index(string service, string model, string resource)
        {
            // /models/waste/Collection

            string view;
            if (service != null)
            {
                if (resource == null)
                    view = String.Concat("~/views/models/", service, "/", model, "/index.cshtml");
                else
                    view = String.Concat("~/views/models/", service, "/", model, "/", resource, ".cshtml");
            }
            else
            {
                if (resource == null)
                    view = String.Concat("~/views/models/", model, "/index.cshtml");
                else
                    view = String.Concat("~/views/models/", model, "/", resource, ".cshtml");
            }

            // get the json if we have one
            string webRootPath = _hostingEnvironment.ContentRootPath;
            string jfile = webRootPath + "/metadata/models/" + service + "/" + model + ".json";
            if (System.IO.File.Exists(jfile))
            {
                using (StreamReader r = new StreamReader(jfile))
                {
                    ViewBag.Json = r.ReadToEnd();
                }
            }
            
            string jfileSample = webRootPath + "/metadata/models/" + service + "/" + model + "-sample.json";
            if (System.IO.File.Exists(jfileSample))
            {
                using (StreamReader r = new StreamReader(jfileSample))
                {
                    ViewBag.JsonSample = r.ReadToEnd();
                }
            }

            return View(view);
        }

        [Route("/models/waste/materials/{material}")]
        public IActionResult Materials(string material)
        {
            // /models/waste/materials/flowers

            string view = String.Concat("~/views/models/waste/materials/index.cshtml");
            ViewBag.Section = Uri.EscapeDataString(material);
            return View(view);
        }
    }
}
