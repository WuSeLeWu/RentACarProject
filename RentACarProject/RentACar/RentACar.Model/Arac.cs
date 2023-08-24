using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblArac")]
    public class Arac
    {
        public int Id { get; set; }
        public int MarkaId { get; set; }
        public int ModelId { get; set; }
        public int YakitTipId { get; set; }
        public int SubeId { get; set; }
        public bool AracDurum { get; set; }
        public string? Foto { get; set; }
        public bool VitesTip { get; set; }
        public int KmSinir { get; set; }
        public decimal DepozitoUcret { get; set; }
        public DateTime? UretimYil { get; set; }
        public int KoltukSayi { get; set; }
        public decimal Fiyat { get; set; }
        public string? Aciklama { get; set; }

        public virtual Model AracModel { get; set; }
        public virtual Marka AracMarka { get; set; }
        public virtual YakitTip AracYakitTipi { get; set; }
        public virtual Sube AracSubesi{ get; set; }

    }
}
