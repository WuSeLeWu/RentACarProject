using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class KartTipRepository : RepositoryBase<KartTip>
    {
        public KartTipRepository(RepositoryContext context) : base(context)
        {

        }


    }
}
