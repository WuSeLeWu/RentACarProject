using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class SehirRepository : RepositoryBase<Sehir>
    {
        public SehirRepository(RepositoryContext context) : base(context)
        {

        }


    }
}
