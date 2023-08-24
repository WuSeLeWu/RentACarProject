using Microsoft.AspNetCore.Mvc;
using RentACar.Web.Models;
using System.Diagnostics;

namespace RentACar.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public IActionResult Index()=> View();
        public IActionResult Iletisim()=> View();
        public IActionResult UyeOl()=> View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}