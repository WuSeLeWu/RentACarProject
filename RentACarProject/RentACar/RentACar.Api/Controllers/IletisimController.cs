using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using RentACar.Model;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimController : BaseController
    {
        public IletisimController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }

        [HttpGet("TumMesajlar")]
        public dynamic TumMesajlar()
        {
            List<Iletisim> items = repo.IletisimRepository.FindAll().ToList<Iletisim>();
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

            Iletisim item = new Iletisim()
            {
                Id = json.Id,
                AdSoyad=json.AdSoyad,
                Mesaj=json.Mesaj,
                KonuBasligi=json.KonuBasligi,
                TelNo=json.TelNo,
                MailAdress=json.MailAdress
                
            };


            if (item.Id > 0)
            {
                repo.IletisimRepository.Update(item);
            }
            else
            {
                repo.IletisimRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true,
            };
        }
    }
}
