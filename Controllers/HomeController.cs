using AutomaticSave.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutomaticSave.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        string currentTime = "";
        public IActionResult Index()
        {
            currentTime = Request.Cookies["Time"] ?? DateTime.Now.ToString();

            Response.Cookies.Append("Time", currentTime, new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(1),
                HttpOnly = true,
                IsEssential = true
            });

            Response.Cookies.Delete("Time");
            ViewBag.Time = currentTime;
            
            return View();

        }
        //I don't know
        [HttpPost]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        

    } }
