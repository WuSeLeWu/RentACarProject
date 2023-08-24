using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RentACar.Api.Code.Validations;
using RentACar.Model;
using RentACar.Model.Views;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubeController : BaseController
    {
        public SubeController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumSubeler")]
        public dynamic TumSubeler()
        {
            List<Sube> items = repo.SubeRepository.FindAll().ToList<Sube>();
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

            Sube item = new Sube()
            {
                Id = json.Id,
                RolId = Enums.Roller.SubeSorumlusu,
                SehirId = json.SehirId,
                AcikAdres = json.AcikAdres,
                Ad=json.Ad,
                Parola=json.Parola,
                //KayitTarih=json.KayitTarih,
                TelNo=json.TelNo,
                MailAdress=json.MailAdress,
                AktifMi=json.AktifMi,
                
            };


            if (item.Id > 0)
            {
                repo.SubeRepository.Update(item);
            }
            else
            {
                repo.SubeRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }

        [HttpGet("SubeTamBilgiler")]
        public dynamic SubeTamBilgiler()
        {
            List<V_SubeTamBilgiler> items = repo.SubeRepository.SubeTamBilgiler();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("IlIçersindekiSubeler/{ilid}")]
        public dynamic SubeleriGetir(int ilid)
        {
            List<Sube> subeler=repo.SubeRepository.FindByCondition(s=>s.SehirId==ilid).ToList<Sube>();

            return new
            {
                sucess = true,
                data = subeler
            };
        }

        [HttpGet("TumSubeAdlariGetir")]
        public dynamic TumSubeAdlariGetir()
        {
            List<string> subeAdlari = repo.SubeRepository.FindAll().Select(s => s.Ad).ToList();

            return new
            {
                success = true,
                data = subeAdlari
            };
        }

        [HttpPost("UyeOl")]
        public dynamic UyeOl([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            string ad = json.Ad;
            string parola = json.Parola;
            string telNo = json.TelNo;
            int sehirId=json.SehirId;
            string acikAdres = json.AcikAdres;
            string mailAdress = json.MailAdress;

            Sube item = new Sube()
            {
                AktifMi = true,
                Ad = ad,
                Parola = parola,
                TelNo = telNo,
                SehirId = sehirId,
                AcikAdres = acikAdres,
                MailAdress = mailAdress,
                RolId = Enums.Roller.SubeSorumlusu
            };

            Sube? kullanici = repo.SubeRepository.FindByCondition(k => k.Ad == item.Ad).SingleOrDefault<Sube>();
            if (kullanici != null)
            {
                return new
                {
                    success = false,
                    message = "Bu kullanıcı adı zaten kullanılıyor"
                };
            }

            SubeValidator validator = new SubeValidator();
            validator.ValidateAndThrow(item);

            repo.SubeRepository.Create(item);
            repo.SaveChanges();

            return new
            {
                success = true
            };
        }
    }
}
