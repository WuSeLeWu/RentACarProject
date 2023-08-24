using Microsoft.AspNetCore.Mvc;
using RentACar.Web.Code.Rest;
using RentACar.Web.Code;
using RentACar.Web.Models;

namespace RentACar.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()=>View();
        public IActionResult GirisYap(LoginModel model) {

            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.MailAdress, model.Parola);

            bool success = result.success;

            if (success)
            {
                Repo.Session.MailAdress = model.MailAdress;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;



                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }
        }

        public IActionResult LoginSube() => View();

        public IActionResult GirisYapSube(LoginModelSube model)
        {
            SubeRestClient client = new SubeRestClient();
            dynamic result = client.LoginSube(model.MailAdress, model.Parola);

            bool success = result.success;

            if (success)
            {
                Repo.Session.MailAdress = model.MailAdress;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Rol = (string)result.rol;

                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewBag.LoginError = (string)result.message;
                return View("LoginSube");
            }
        }


        public IActionResult CikisYap()
        {
            Repo.Session.MailAdress = "";
            Repo.Session.Token = "";
            Repo.Session.Rol = "";

            return RedirectToAction("Index", "Home");
        }
    }
}
