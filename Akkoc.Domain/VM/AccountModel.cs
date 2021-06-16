using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.VM
{
    public class AccountModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz.")]
        [StringLength(10,ErrorMessage ="Kullanıcı adı 10 karakteri geçemez.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Parola boş bırakılamaz.")]
        [StringLength(10, ErrorMessage = "Parola adı 10 karakteri geçemez.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
