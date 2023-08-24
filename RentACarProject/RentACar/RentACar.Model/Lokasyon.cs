using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblLokasyon")]
    public class Lokasyon
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int SehirId { get; set; }

        public virtual Sehir LokasyonSehri { get; set; }
    }
}
