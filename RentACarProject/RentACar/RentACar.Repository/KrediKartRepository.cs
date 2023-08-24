using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class KrediKartRepository : RepositoryBase<KrediKart>
    {
        public KrediKartRepository(RepositoryContext context) : base(context)
        {

        }


    }
}
