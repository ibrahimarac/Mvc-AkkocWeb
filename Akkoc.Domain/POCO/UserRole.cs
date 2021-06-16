using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{
    [Table("Roles")]
    public class UserRole:Base
    {
        [Display(Name = "Rol adı")]
        [Column(TypeName = "varchar", Order = 2)]
        [Required(ErrorMessage = "Rol adı gereklidir.")]
        [StringLength(10, ErrorMessage = "Rol adı en fazla 10 karakter olabilir.")]
        public string RoleName { get; set; }

        [Display(Name = "Rol adı")]
        [Column(TypeName = "varchar", Order = 3)]
        [StringLength(255, ErrorMessage = "Açıklama en fazla 255 karakter olabilir.")]
        public string Description { get; set; }

        public virtual ICollection<LoginUser> Logins { get; set; }

        public UserRole()
        {
            Logins = new HashSet<LoginUser>();
        }
    }
}
