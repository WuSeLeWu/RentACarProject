using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model.Views
{
    [Table("V_SubeTamBilgiler")]
    public class V_SubeTamBilgiler
    {
        public int Id { get; set; }
        public int SehirId { get; set; }
        public int RolId { get; set; }
        public string Ad { get; set; }
        public string SehirAd { get; set; }
        public string RolAd { get; set; }
        public string AcikAdres { get; set; }
        public string Parola { get; set; }
        public DateTime? KayitTarih { get; set; }
        public string TelNo { get; set; }
        public string MailAdress { get; set; }
        public bool AktifMi { get; set; }
    }
}
