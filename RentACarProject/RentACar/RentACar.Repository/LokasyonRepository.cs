using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class LokasyonRepository : RepositoryBase<Lokasyon>
    {
        public LokasyonRepository(RepositoryContext context) : base(context)
        {

        }


    }
}
