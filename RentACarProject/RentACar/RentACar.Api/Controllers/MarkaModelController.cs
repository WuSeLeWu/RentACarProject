using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RentACar.Model;
using RentACar.Repository;
using System.Linq;

namespace RentACar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaModelController : BaseController
    {
        public MarkaModelController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }

        [HttpGet("TumMarkalar")]
        public dynamic TumMarkalar()
        {
            List<Marka> items = repo.MarkaRepository.FindAll().ToList<Marka>();
            return new
            {
                success = true,
                data = items
            };
        }

        [HttpGet("ModellereGoreMarkalar/{markaId}")]
        public dynamic ModellerByMarka(int markaId)
        {
            List<Model.Model> modeller = repo.ModelRepository.FindByCondition(m => m.MarkaId == markaId).ToList();
            return new
            {
                success = true,
                data = modeller
            };
        }

    }
}
