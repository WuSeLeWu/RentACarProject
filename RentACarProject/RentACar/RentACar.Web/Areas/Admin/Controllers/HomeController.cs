using Microsoft.AspNetCore.Mvc;
using RentACar.Web.Code.Filters;

namespace RentACar.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthActionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index()=> View();

        [AuthActionFilter(Rol ="Admin")]
        public IActionResult Rol()=> View();
        [AuthActionFilter(Rol = "Admin")]
        public IActionResult Arac()=> View();
        [AuthActionFilter(Rol = "Admin")]
        public IActionResult Kullanici()=> View();
        [AuthActionFilter(Rol = "Admin")]
        public IActionResult Sube()=> View();
        [AuthActionFilter(Rol = "Admin,MusteriTemsilcisi")]
        public IActionResult Iletisim()=> View();

    }
}
