using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblRezervasyon")]
    public class Rezervasyon
    {
        public int Id { get; set; }
        public int AracId { get; set; }
        public int KullaniciId { get; set; }
        public int TeslimAlimLokasyonId { get; set; }
        public int IadeLokasyonId { get; set; }
        public DateTime TeslimAlimTarih { get; set; }
        public DateTime IadeTarih { get; set; }

        public virtual Arac RezervasyonAracı { get; set; }
        public virtual Kullanici RezervasyonKullanicisi{ get; set; }
        public virtual Lokasyon RezervasyonTeslimLokasyonu { get; set; }
        public virtual Lokasyon RezervasyonIadeLokasyonu { get; set; }

    }
}
