using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Model
{
    [Table("tblModel")]
    public class Model
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public int MarkaId { get; set; }

        public virtual Marka Marka { get; set; }
    }
}
