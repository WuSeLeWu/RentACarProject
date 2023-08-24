using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentACar.Model;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YakitTipController : BaseController
    {
        public YakitTipController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumYakitAdlariniGetir")]
        public dynamic TumYakitAdlariniGetir()
        {
            List<string> yakitAdlari = repo.YakitTipRepository.FindAll().Select(s => s.Ad).ToList();

            return new
            {
                success = true,
                data = yakitAdlari
            };
        }

        [HttpGet("TumYakitTipleri")]
        public dynamic TumMarkalar()
        {
            List<YakitTip> items = repo.YakitTipRepository.FindAll().ToList<YakitTip>();
            return new
            {
                success = true,
                data = items
            };
        }
    }
}
