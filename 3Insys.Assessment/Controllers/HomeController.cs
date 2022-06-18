using _3Insys.Assessment.ClientFactory;
using _3Insys.Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3Insys.Assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpClientServiceImplementation _httpClientServiceImplementation;

        public HomeController(ILogger<HomeController> logger, IHttpClientServiceImplementation httpClient)
        {
            _logger = logger;
            _httpClientServiceImplementation = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _httpClientServiceImplementation.GetListOfAllTshirs();
            return View("Index", list);
        }

        public async Task<IActionResult> Save(int Id)
        {
            var model = await _httpClientServiceImplementation.GetDetailofShirt(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(ManageTShirtModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.tShirt.ImageFile != null && model.tShirt.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        model.tShirt.ImageFile.CopyTo(ms);
                        model.tShirt.Image = ms.ToArray();
                    }
                }
                await _httpClientServiceImplementation.Save(model.tShirt);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClientServiceImplementation.Delete(id);

            return Json(false);
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var model = await _httpClientServiceImplementation.GetDetailofShirt(id);

            return View("Details", model);
        }


    }
}
