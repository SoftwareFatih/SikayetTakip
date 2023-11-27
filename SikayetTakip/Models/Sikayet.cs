using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SikayetTakip.Models
{
    [Table("sikayetler")]
    public class Sikayet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Şikayet Başlığı:")]
        public string Baslik { get; set; }
        [Required]
        [Display(Name = "Şikayet Detayı:")]
        [DataType(DataType.MultilineText)]
        public string Detay { get; set; }
        [Required]
        [Display(Name ="Kayıt Tarihi:")]
        public DateTime KayitTarih { get; set; }

        [ForeignKey("Musteri")]
        public int MusteriId { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}