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
    public class Category:Base
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Order = 0;
        }

        [Column(TypeName ="varchar",Order =2)]
        [Required(ErrorMessage ="Kategori adı boş bırakılamaz.")]
        [StringLength(30,ErrorMessage ="Kategori adı en fazla 30 karakter olabilir.")]
        [Display(Name="Kategori adı")]
        
        public string Name { get; set; }

        [Column(TypeName = "varchar",Order =3)]
        [StringLength(255)]
        [Display(Name="Açıklama")]
        [AllowHtml]
        [Required(ErrorMessage ="Açıklama alanı gereklidir.")]
        public string Description { get; set; }

        [Display(Name="Önceliği")]
        [Required(ErrorMessage ="Öncelik alanı gereklidir.")]
        [Range(0,300,ErrorMessage ="Öncelik bilgisi 0-300 arasında bir değer olmalıdır.")]
        [Column(Order =4)]
        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
