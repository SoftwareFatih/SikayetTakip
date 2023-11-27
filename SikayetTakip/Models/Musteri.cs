using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SikayetTakip.Models
{
    [Table("musteriler")]
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Ad Soyad")]
        public string AdSoyad { get; set; }
        public virtual ICollection<Sikayet> Sikayetler { get; set; }

    }
}