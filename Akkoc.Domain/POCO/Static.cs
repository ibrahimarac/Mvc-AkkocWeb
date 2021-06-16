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
    [Table("SiteStatics")]
    public class Static:Base
    {
        [Required(ErrorMessage ="Hakkımızda sayfasına başlık girmediniz.")]
        [Column(Order =2,TypeName ="varchar")]
        [StringLength(100,ErrorMessage ="Hakkımızda sayfasının başlığı 100 karakteri geçemez.")]
        [Display(Name ="Hakkımızda sayfasının başlığı")]
        public string AboutTitle { get; set; }

        [Required(ErrorMessage = "Hakkımızda sayfasına içerik girmediniz.")]
        [Column(Order = 3, TypeName = "varchar")]
        [StringLength(8000, ErrorMessage = "Hakkımızda sayfasının içeriği 8000 karakteri geçemez.")]
        [Display(Name = "Hakkımızda sayfasının içeriği")]
        [AllowHtml]
        public string AboutDescription { get; set; }

        [Required(ErrorMessage = "Instagram adresini girmediniz.")]
        [Column(Order = 4, TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Instagram adresi 50 karakteri geçemez.")]
        [Display(Name = "Instagram adresiniz")]
        public string Instagram { get; set; }

        [Column(Order = 5, TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Video dosyasının adı 50 karakteri geçemez.")]
        [Display(Name = "Varsa tanıtım videonuz")]
        public string VideoFile { get; set; }

        [Required(ErrorMessage = "Instagram etiketi girmediniz.")]
        [Column(Order = 6, TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "Instagram etiketi 20 karakteri geçemez.")]
        [Display(Name = "Instagram etiketiniz")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Birinci eposta adresi boş bırakılamaz.")]
        [Column(Order = 7, TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "Eposta adresi 100 karakteri geçemez.")]
        [Display(Name = "1. eposta adresi")]
        public string Email1 { get; set; }
        
        [Column(Order = 8, TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "Eposta adresi 100 karakteri geçemez.")]
        [Display(Name = "2. eposta adresi")]
        public string Email2 { get; set; }

        [Required(ErrorMessage = "Birinci telefon numarası boş bırakılamaz.")]
        [Column(Order = 9, TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "Telefon numarası 15 karakteri geçemez.")]
        [Display(Name = "1. telefon numarası")]
        [RegularExpression(@"^(\(\d{3}\)) (\d{3}) (\d{2}) (\d{2})$", ErrorMessage ="Telefon numarası (XXX) XXX XX XX şablonuna uygun olmalıdır.")]
        public string Tel1 { get; set; }


        [Column(Order = 10, TypeName = "varchar")]
        [StringLength(15, ErrorMessage = "Telefon numarası 15 karakteri geçemez.")]
        [Display(Name = "2. telefon numarası")]
        [RegularExpression(@"^(\(\d{3}\)) (\d{3}) (\d{2}) (\d{2})$", ErrorMessage = "Telefon numarası (XXX) XXX XX XX şablonuna uygun olmalıdır.")]
        public string Tel2 { get; set; }

        [Display(Name ="Google harita linki")]
        [Required(ErrorMessage ="Google harita linki zorunludur.")]
        [Column(Order = 11)]
        [StringLength(1500)]
        [AllowHtml]
        public string Location { get; set; }

        [Required(ErrorMessage = "Site yönetici eposta adresi boş bırakılamaz.")]
        [Column(Order = 12, TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "Yönetici eposta adresi 100 karakteri geçemez.")]
        [Display(Name = "Yönetici eposta adresi")]
        public string SiteMail { get; set; }

        [Required(ErrorMessage = "Yönetici mail kullanıcı adı boş bırakılamaz.")]
        [Column(Order = 13, TypeName = "varchar")]
        [StringLength(20, ErrorMessage = "Yönetici mail kullanıcı adı 20 karakteri geçemez.")]
        [Display(Name = "Yönetici mail kullanıcı adı")]
        public string MailUserName { get; set; }

        [Required(ErrorMessage = "Yönetici mail parolası boş bırakılamaz.")]
        [Column(Order = 14, TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "Yönetici mail parolası 10 karakteri geçemez.")]
        [Display(Name = "Yönetici mail parolası")]
        public string MailPassword { get; set; }

        [Required(ErrorMessage = "Copyright bilgisi boş bırakılamaz.")]
        [Column(Order = 15, TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "Copyright bilgisi 200 karakteri geçemez.")]
        [Display(Name = "Copyright bilgisi")]
        public string Copyrigth { get; set; }

        [Column(Order = 16, TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "Facebook adresi 200 karakteri geçemez.")]
        [Display(Name = "Facebook adresi")]
        [DataType(DataType.Url)]
        public string FacebookUrl { get; set; }

        [Column(Order = 17, TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "Instagram adresi 200 karakteri geçemez.")]
        [Display(Name = "Instagram adresi")]
        [DataType(DataType.Url)]
        public string InstagramUrl { get; set; }

        [Column(Order = 18, TypeName = "varchar")]
        [StringLength(200, ErrorMessage = "Pinterest adresi 200 karakteri geçemez.")]
        [Display(Name = "Pinterest adresi")]
        [DataType(DataType.Url)]
        public string PinterestUrl { get; set; }

        [Column(Order = 19, TypeName = "varchar")]
        [StringLength(50, ErrorMessage = "Logo başlık metni 50 karakteri geçemez.")]
        [Display(Name = "Logo başlık metni")]
        public string LogoTitle { get; set; }

        [Column(Order = 20, TypeName = "varchar")]
        [StringLength(50)]
        [Display(Name = "Logo resmi")]
        public string LogoImage { get; set; }
    }
}
