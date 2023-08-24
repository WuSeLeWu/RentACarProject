using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RentACar.Api.Code.Validations;
using RentACar.Model;
using RentACar.Model.Views;
using RentACar.Repository;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }

        [HttpGet("TumKullanicilar")]
        public dynamic TumKullanicilar()
        {
            List<Kullanici> items = repo.KullaniciRepository.FindAll().ToList<Kullanici>();
            return new
            {
                success = true,
                data = items
            };
        }

        [Authorize("Admin,Personel")]
        [HttpGet("RoleGoreKullaniciGetir/{id}")]
        public dynamic RoleGoreKullaniciGetir(int id)
        {
            List<Kullanici> items = repo.KullaniciRepository.FindByCondition(a => a.RolId == id).ToList<Kullanici>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("KullaniciTamBilgiler")]
        public dynamic KullaniciTamBilgiler()
        {
            List<V_KullaniciTamBilgiler> items = repo.KullaniciRepository.KullaniciTamBilgiler();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string ad = json.Ad;
            string soyad = json.Soyad;
            string parola = json.Parola;
            int sehirId=json.SehirId;
            string telNo = json.TelNo;
            string tcKimlikNo = json.TcKimlikNo;
            string acikAdres = json.AcikAdres;
            DateTime dogumTarih = json.DogumTarih;
            string mailAdress = json.MailAdress;
            DateTime ehliyetAlim = json.EhliyetAlimTarih;

            Kullanici item = new Kullanici()
            {
                AktifMi = true,
                Ad = ad,
                Soyad = soyad,
                Parola = parola,
                SehirId = sehirId,
                TelNo = telNo,
                TcKimlikNo = tcKimlikNo,
                AcikAdres = acikAdres,
                DogumTarih = dogumTarih,
                MailAdress = mailAdress,
                EhliyetAlimTarih = ehliyetAlim,
                RolId = Enums.Roller.Musteri
            };

            Kullanici? kullanici = repo.KullaniciRepository.FindByCondition(k => k.Ad == item.Ad).SingleOrDefault<Kullanici>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu kullanıcı adı zaten kullanılıyor"
                };
            }

            KullaniciValidator validator = new KullaniciValidator();
            validator.ValidateAndThrow(item);

            repo.KullaniciRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kullanici item = new Kullanici()
            {
                Id = json.Id,
                RolId = json.RolId,
                SehirId = json.SehirId,
                AcikAdres = json.AcikAdres,
                Ad = json.Ad,
                Soyad = json.Soyad,
                Parola = json.Parola,
                TelNo = json.TelNo,
                TcKimlikNo = json.TcKimlikNo,
                MailAdress = json.MailAdress,
                AktifMi = json.AktifMi,
                DogumTarih = json.DogumTarih,
                EhliyetAlimTarih = json.EhliyetAlimTarih
            };


            if (item.Id > 0)
            {
                repo.KullaniciRepository.Update(item);
            }
            else
            {
                repo.KullaniciRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }
    }
}
