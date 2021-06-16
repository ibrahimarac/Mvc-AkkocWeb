using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{
    [Table("Logins")]
    public class LoginUser:Base
    {
        [ForeignKey("Role")]
        [Column(Order=2)]
        public int RoleId { get; set; }
        
        public UserRole Role { get; set; }

        [Display(Name="Kullanıcı adı")]
        [Column(TypeName ="varchar",Order =3)]
        [Required(ErrorMessage ="Kullanıcı adı gereklidir.")]
        [StringLength(8,ErrorMessage ="Kullanıcı adı en fazla 8 karakter olabilir.")]
        public string UserName { get; set; }

        [Display(Name = "Parola")]
        [Column(TypeName = "varchar", Order = 4)]
        [Required(ErrorMessage = "Parola gereklidir.")]
        [StringLength(8, ErrorMessage = "Parola en fazla 8 karakter olabilir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Adı")]
        [Column(TypeName = "varchar", Order = 5)]
        [Required(ErrorMessage = "Kullanıcının ismi gereklidir.")]
        [StringLength(30, ErrorMessage = "Kullanıcı ismi en fazla 30 karakter olabilir.")]
        public string Name { get; set; }

        [Display(Name = "Soyadı")]
        [Column(TypeName = "varchar", Order = 6)]
        [Required(ErrorMessage = "Kullanıcının soyadı gereklidir.")]
        [StringLength(30, ErrorMessage = "Kullanıcı soyadı en fazla 30 karakter olabilir.")]
        public string Surname { get; set; }

        [Display(Name = "Resim")]
        [Column(TypeName = "varchar", Order = 7)]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string UserImage { get; set; }

        [ScaffoldColumn(false)]
        [Column(Order=8)]
        public DateTime LastLoginDate { get; set; }

        public LoginUser()
        {
            LastLoginDate = DateTime.Now;
        }
    }
}
