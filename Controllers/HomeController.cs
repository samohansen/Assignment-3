using Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private MovieFormContext context { get; set; }
        public HomeController(MovieFormContext con)
        {
            context = con;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            // Return data stored in the MovieFormModel database
            return View(context.Movies);
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }


        // POST Method: Commit to Database
        [HttpPost]
        public IActionResult MovieForm(MovieFormModel submission)
        {
            if (ModelState.IsValid)
            {
                context.Movies.Add(submission);
                context.SaveChanges();
            }
            //TempStorage.AddMovie(appResponse);
            //Debug.WriteLine("Title: " + appResponse.Title);
            return View("Confirmation");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
