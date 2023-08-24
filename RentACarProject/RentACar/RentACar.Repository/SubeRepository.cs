using RentACar.Model;
using RentACar.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class SubeRepository : RepositoryBase<Sube>
    {
        public SubeRepository(RepositoryContext context) : base(context)
        {

        }

        public List<V_SubeTamBilgiler> SubeTamBilgiler()
        {
            return RepositoryContext.SubeTamBilgiler.ToList<V_SubeTamBilgiler>();
        }
    }
}
