using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblSube")]
    public class Sube
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int SehirId { get; set; }
        public string AcikAdres { get; set; }
        public string Ad { get; set; }
        public string Parola { get; set; }
        public DateTime? KayitTarih { get; set; }
        public string TelNo { get; set; }
        public string MailAdress { get; set; }
        public bool AktifMi { get; set; }

        public virtual Sehir SubeSehri { get; set; }
        public virtual Rol SubeRolu { get; set; }

    }
}
