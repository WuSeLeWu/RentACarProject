using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Model
{
    [Table("tblMarka")]
    public class Marka
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string? LogoFoto { get; set; }
    }
}