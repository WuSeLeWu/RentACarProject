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
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>().Property(d => d.KayitTarih).HasDefaultValue();
            modelBuilder.Entity<Sube>().Property(d => d.KayitTarih).HasDefaultValue();
            modelBuilder.Entity<V_AracTamBilgiler>().HasNoKey();
            modelBuilder.Entity<V_AracTamBilgilerAktif>().HasNoKey();
            modelBuilder.Entity<V_SubeTamBilgiler>().HasNoKey();
            modelBuilder.Entity<V_KullaniciTamBilgiler>().HasNoKey();

        }

        public DbSet<Arac> Araclar { get; set; }
        public DbSet<KartTip> KartTipleri { get; set; }
        public DbSet<KrediKart> KrediKart { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Lokasyon> Lokasyonlar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Model.Model> Modeller { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Sehir> Sehirler { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<YakitTip> YakitTipleri { get; set; }
        public DbSet<Iletisim> Mesajlar { get; set; }


        public DbSet<V_AracTamBilgiler> AracTamBilgiler { get; set; }
        public DbSet<V_AracTamBilgilerAktif> AracTamBilgilerAktif { get; set; }
        public DbSet<V_SubeTamBilgiler> SubeTamBilgiler { get; set; }
        public DbSet<V_KullaniciTamBilgiler> KullaniciTamBilgiler { get; set; }


    }
}
