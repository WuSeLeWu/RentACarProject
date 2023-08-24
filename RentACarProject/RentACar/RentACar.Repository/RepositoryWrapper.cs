using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Repository
{
    public  class RepositoryWrapper
    {
        private RepositoryContext context;

        private KullaniciRepository kullaniciRepository;
        private RolRepository rolRepository;
        private MarkaRepository markaRepository;
        private LokasyonRepository lokasyonRepository;
        private AracRepository aracRepository;
        private SubeRepository subeRepository;
        private YakitTipRepository yakitTipRepository;
        private ModelRepository modelRepository;
        private SehirRepository sehirRepository;
        private IletisimRepository iletisimRepository;
        private V_AracAktifRepository v_AracAktifRepository;

        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        public V_AracAktifRepository V_AracAktifRepository
        {
            get
            {
                if (v_AracAktifRepository == null)
                    v_AracAktifRepository = new V_AracAktifRepository(context);
                return v_AracAktifRepository;
            }
        }

        public SehirRepository SehirRepository
        {
            get
            {
                if (sehirRepository == null)
                    sehirRepository = new SehirRepository(context);
                return sehirRepository;
            }
        }

        public IletisimRepository IletisimRepository
        {
            get
            {
                if (iletisimRepository == null)
                    iletisimRepository = new IletisimRepository(context);
                return iletisimRepository;
            }
        }

        public KullaniciRepository KullaniciRepository
        {
            get
            {
                if (kullaniciRepository == null)
                    kullaniciRepository = new KullaniciRepository(context);
                return kullaniciRepository;
            }
        }

        public YakitTipRepository YakitTipRepository
        {
            get
            {
                if (yakitTipRepository == null)
                    yakitTipRepository = new YakitTipRepository(context);
                return yakitTipRepository;
            }
        }

        public ModelRepository ModelRepository
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new ModelRepository(context);
                return modelRepository;
            }
        }

        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;
            }
        }

        public MarkaRepository MarkaRepository
        {
            get
            {
                if (markaRepository == null)
                    markaRepository = new MarkaRepository(context);
                return markaRepository;
            }
        }

        public LokasyonRepository LokasyonRepository
        {
            get
            {
                if (lokasyonRepository == null)
                    lokasyonRepository = new LokasyonRepository(context);
                return lokasyonRepository;
            }
        }

        public AracRepository AracRepository
        {
            get
            {
                if (aracRepository == null)
                    aracRepository = new AracRepository(context);
                return aracRepository;
            }
        }

        public SubeRepository SubeRepository
        {
            get
            {
                if (subeRepository == null)
                    subeRepository = new SubeRepository(context);
                return subeRepository;
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
