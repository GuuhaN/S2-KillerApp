using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using S2_KillerApp_ASPNET.Models;

namespace S2_KillerApp_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
         {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
