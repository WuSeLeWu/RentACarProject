using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblKullanici")]
    public class Kullanici
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int SehirId { get; set; }
        public string AcikAdres { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Parola { get; set; }
        public string TelNo { get; set; }
        public string TcKimlikNo { get; set; }
        public string MailAdress { get; set; }
        public DateTime DogumTarih { get; set; }
        public DateTime EhliyetAlimTarih { get; set; }
        public DateTime? KayitTarih { get; set; }
        public bool AktifMi { get; set; }

        public virtual Rol KullaniciRolu { get; set; }
        public virtual Sehir KullaniciSehri { get; set; }
    }
}
