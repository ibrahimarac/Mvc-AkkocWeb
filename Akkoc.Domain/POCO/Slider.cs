using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Akkoc.Domain.POCO
{
    [Table("Sliders")]
    public class Slider:Base
    {
        [Column(TypeName="varchar",Order =2),StringLength(100,ErrorMessage ="Slider başlığı 100 karakteri geçemez.")]
        [Required(ErrorMessage ="Slider başlığı gereklidir.")]
        [Display(Name ="Başlık")]
        public string Title { get; set; }

        [Column(TypeName = "varchar",Order =3), StringLength(255, ErrorMessage = "Slider başlığı 255 karakteri geçemez.")]
        [Required(ErrorMessage = "Açıklama alanı gereklidir.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Column(TypeName = "varchar",Order =4), StringLength(100, ErrorMessage = "Eposta adresi 100 karakteri geçemez.")]
        [Required(ErrorMessage = "Eposta adresi gereklidir.")]
        [Display(Name = "Eposta adresi")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Yazılan adres geçerli bir eposta adresi değil.")]
        public string Email { get; set; }

        [Display(Name = "Önceliği")]
        [Required(ErrorMessage = "Öncelik alanı gereklidir.")]
        [Range(0, 300, ErrorMessage = "Öncelik bilgisi 0-300 arasında bir değer olmalıdır.")]
        [Column(Order = 5)]
        public int Order { get; set; }

        [Column(TypeName = "varchar",Order =6), StringLength(100)]
        public string SliderImage { get; set; }

        [AllowHtml]
        [Column(TypeName = "varchar", Order = 7), StringLength(8000, ErrorMessage = "Slider detayı 8000 karakteri geçemez.")]
        [Required(ErrorMessage = "Slider detayı gereklidir.")]
        [Display(Name = "Slider içeriği")]
        public string Detail { get; set; }
    }
}
