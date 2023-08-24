using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentACar.Model;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokasyonController : BaseController
    {
        public LokasyonController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("SehirIdLokasyon/{id}")]
        public dynamic SehirdekiLokasyonlar(int id)
        {
            List<Lokasyon> items = repo.LokasyonRepository.FindByCondition(a => a.SehirId == id).ToList<Lokasyon>();
            return new
            {
                success = true,
                data = items
            };
        }
    }
}
