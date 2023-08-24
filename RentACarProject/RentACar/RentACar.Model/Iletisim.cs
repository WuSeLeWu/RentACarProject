using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblIletisim")]
    public class Iletisim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string MailAdress { get; set; }
        public string KonuBasligi { get; set; }
        public string TelNo { get; set; }
        public string Mesaj { get; set; }
    }
}
