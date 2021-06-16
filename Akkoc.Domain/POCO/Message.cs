using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{
    public class Message
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(TypeName = "varchar", Order = 2)]
        [Required(ErrorMessage = "Adınızı girmelisiniz.")]
        [StringLength(30, ErrorMessage = "Adınız en fazla 30 karakter olabilir.")]
        [Display(Name = "Adınız")]
        public string Name { get; set; }

        [Column(TypeName = "varchar", Order = 3)]
        [Required(ErrorMessage = "Adınızı girmelisiniz.")]
        [StringLength(30, ErrorMessage = "Konu bilgisi en fazla 30 karakter olabilir.")]
        [Display(Name = "Konu")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Eposta adresi boş bırakılamaz.")]
        [Column(Order = 4, TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "Eposta adresi 100 karakteri geçemez.")]
        [Display(Name = "Eposta adresiniz")]
        public string Email { get; set; }

        [Column(TypeName = "varchar", Order = 5)]
        [StringLength(255,ErrorMessage ="Mesaj bilgisi en fazla 255 karakter olabilir.")]
        [Display(Name = "Mesajınız")]
        [Required(ErrorMessage = "Mesaj girilmelidir.")]
        public string  Content { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsRead { get; set; }

        public bool IsActive { get; set; }

        public Message()
        {
            CreateDate = DateTime.Now;
            IsActive = true;
            IsRead = false;
        }
    }
}
