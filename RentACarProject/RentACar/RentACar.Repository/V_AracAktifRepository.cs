using RentACar.Model.Views;
using RentACar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class V_AracAktifRepository : RepositoryBase<V_AracTamBilgilerAktif>
    {
        public V_AracAktifRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
