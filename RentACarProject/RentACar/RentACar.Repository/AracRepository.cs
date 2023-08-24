using Microsoft.EntityFrameworkCore;
using RentACar.Model;
using RentACar.Model.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public class AracRepository : RepositoryBase<Arac>
    {
        public AracRepository(RepositoryContext context) : base(context)
        {

        }

        public void Sil(int Id)
        {
            RepositoryContext.Araclar.Where(r => r.Id == Id).ExecuteDelete();
        }

        public List<V_AracTamBilgiler> AracTamBilgiler()
        {
            return RepositoryContext.AracTamBilgiler.ToList<V_AracTamBilgiler>();
        }

        public List<V_AracTamBilgilerAktif> AracTamBilgilerAktif()
        {
            return RepositoryContext.AracTamBilgilerAktif.ToList<V_AracTamBilgilerAktif>();
        }

        public V_AracTamBilgiler AracById(int id)
        {
            V_AracTamBilgiler arac = (from a in RepositoryContext.AracTamBilgiler where a.Id == id select a).SingleOrDefault<V_AracTamBilgiler>();

            return arac;
        }

        public List<Arac> GetAraclarBySubeMailAndSubeId(string subeMail, int subeId)
        {
            return RepositoryContext.Araclar
                .Where(a => a.AracSubesi.MailAdress == subeMail && a.SubeId == subeId)
                .ToList();
        }
    }
}
