using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblKrediKart")]
    public class KrediKart
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; }
        public int KartTipId { get; set; }
        public string KartSahipAd { get; set; }
        public string KartNo { get; set; }
        public DateTime SonKullanmaTarih { get; set; }
        public string GuvenlikKod { get; set; }

        public virtual Kullanici KrediKartKullanicisi { get; set; }
    }
}
