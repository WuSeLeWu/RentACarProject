using Microsoft.AspNetCore.Mvc;
using RentACar.Web.Code.Rest;

namespace RentACar.Web.Areas.Arac.Controllers
{
    [Area("Kiralama")]
    public class AracController : Controller
    {
        public IActionResult Detay(int id)
        {
            AracRestClient client = new AracRestClient();
            dynamic result = client.AracGetir(id);

            bool success = result.success;
            if (success)
                ViewBag.Arac = result.data;

            return View();
        }

        public IActionResult Araclar()
        {
            return View();
        }
    }
}
