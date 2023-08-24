using RentACar.Model;
using RentACar.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class KullaniciRepository : RepositoryBase<Kullanici>
    {
        public KullaniciRepository(RepositoryContext context) : base(context)
        {

        }

        public List<V_KullaniciTamBilgiler> KullaniciTamBilgiler()
        {
            return RepositoryContext.KullaniciTamBilgiler.ToList<V_KullaniciTamBilgiler>();
        }
    }
}
