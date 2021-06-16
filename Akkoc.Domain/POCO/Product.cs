using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Akkoc.Domain.POCO
{
    public class Product:Base
    {
        [ForeignKey("Category")]
        [Column(Order =2)]
        [Display(Name="Kategorisi")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name="Ürünün Adı")]
        [Column(TypeName ="varchar",Order =3)]
        [StringLength(150)]
        [Required(ErrorMessage ="Ürün adı boş bırakılamaz.")]
        public string Name { get; set; }

        [Display(Name="Fiyatı")]
        [DataType(DataType.Currency)]
        [Required,Column(Order =4)]
        public double Price { get; set; }

        [Display(Name="Detaylar")]
        [StringLength(8000)]
        [Required(ErrorMessage ="Açıklama alanı gereklidir."),Column(Order =5)]
        [AllowHtml]
        public string Description { get; set; }

        [Display(Name="Önceliği")]
        [Column(Order =6)]
        public int Order { get; set; }
        
        [Display(Name="Ürün Resmi"),Column(Order =7,TypeName ="varchar")]
        [StringLength(50)]
        public string ProductImage { get; set; }

        [ScaffoldColumn(false), Column(Order = 8,TypeName ="varchar")]
        [StringLength(50)]
        public string ProductThumbImage { get; set; }

        public Product()
        {
            Order = 0;
        }


    }
}
