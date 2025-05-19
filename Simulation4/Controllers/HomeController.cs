using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
//using Simulation4.Models;

namespace Simulation4.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
