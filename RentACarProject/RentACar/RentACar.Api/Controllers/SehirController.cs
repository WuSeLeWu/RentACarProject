using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentACar.Model;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirController : BaseController
    {
        public SehirController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {

        }

        [HttpGet("TumSehirler")]
        public dynamic TumSehirler()
        {
            List<Sehir> items = repo.SehirRepository.FindAll().ToList<Sehir>();
            return new
            {
                success = true,
                data = items
            };
        }
    }
}
