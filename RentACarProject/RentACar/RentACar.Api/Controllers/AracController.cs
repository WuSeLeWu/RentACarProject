using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RentACar.Model;
using RentACar.Model.Views;
using RentACar.Repository;
using RentACar.Web.Code;
using System.Linq;
using System.Security.Claims;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : BaseController
    {

        public AracController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumAraclar")]
        public dynamic TumAraclar()
        {
            List<Arac> items = repo.AracRepository.FindAll().ToList<Arac>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Arac item = new Arac()
            {
                Id = json.Id,
                MarkaId = json.MarkaId,
                ModelId=json.ModelId,
                YakitTipId=json.YakitTipId,
                SubeId=json.SubeId,
                AracDurum=json.AracDurum,
                VitesTip =json.VitesTip,
                Foto = json.Foto,
                KmSinir =json.KmSinir,
                DepozitoUcret=json.DepozitoUcret,
                KoltukSayi=json.KoltukSayi,
                Fiyat=json.Fiyat,
                Aciklama=json.Aciklama,
            };


            if (item.Id > 0)
            {
                repo.AracRepository.Update(item);
            }
            else
            {
                repo.AracRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }
        //Admin-sube görecek
        [HttpGet("AracTamBilgiler")]
        public dynamic AracTamBilgiler()
        {
            List<V_AracTamBilgiler> items = repo.AracRepository.AracTamBilgiler();
            return new
            {
                success = true,
                data = items
            };
        }
        //Herkes Görebilir
        [HttpGet("AracTamBilgilerAktif")]
        public dynamic AracTamBilgilerAktif()
        {
            List<V_AracTamBilgilerAktif> items = repo.AracRepository.AracTamBilgilerAktif();
            return new
            {
                success = true,
                data = items
            };
        }

        //Araç Şubeleri
        //[HttpGet("SubeAraclar")]
        //public IActionResult GetSubeAraclar()
        //{
        //    Repo r = new Repo();
        //    string? subeMail = new HttpContextAccessor().HttpContext.Session.GetString("MailAdress"); ; // Giriş yapan şubenin mail adresi
        //    List<Arac> subeAraclar = repo.AracRepository.FindByCondition(a => a.AracSubesi.MailAdress == subeMail).ToList();

        //    return Ok(new
        //    {
        //        success = true,
        //        data = subeAraclar
        //    });
        //}


        [HttpGet("AracDetayGetir/{id}")]
        public dynamic AracDetayGetir(int id)
        {
            V_AracTamBilgiler detay = repo.AracRepository.AracById(id);

            return new
            {
                success = true,
                data = detay
            };
        }

        [HttpGet("AracMarkalariniGetir/{mid}")]
        public dynamic AracMarkalariniGetir(int mid)
        {
            List<Arac> marka = repo.AracRepository.FindByCondition(a=>a.AracModel.MarkaId==mid).ToList<Arac>();

            return new
            {
                success = true,
                data = marka
            };
        }

        [HttpGet("SubeyeAitAraclariGetir/{sid}")]
        public dynamic SubeyeAitAraclariGetir(int sid)
        {
            List<Arac> subeler = repo.AracRepository.FindByCondition(s=>s.AracSubesi.Id==sid).ToList<Arac>();

            return new
            {
                success = true,
                data = subeler
            };
        }


        [HttpGet("SehirdekiAraclariGetir/{sehir}")]
        public dynamic SehirdekiAraclariGetir(int sehir)
        {
            List<V_AracTamBilgilerAktif> items = repo.V_AracAktifRepository.FindByCondition(s => s.AracSubesi.SubeSehri.Id == sehir).ToList<V_AracTamBilgilerAktif>();

            return new
            {
                success = true,
                data = items
            };
        }

        [HttpDelete("Sil")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz id"
                };
            }

            repo.AracRepository.Sil(id);
            return new
            {
                success = true
            };
        }

    }
}
