using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace Akkoc.Domain.VM
{
    public class LoginWithImage
    {
        public LoginUser LoginModel { get; set; }

        [Required(ErrorMessage ="Parola tekrar alanı zorunludur.")]
        [Display(Name ="Parola tekrar")]
        [StringLength(8,ErrorMessage ="Parola tekrar alanı 8 karakter olabilir.")]
        [Match(ErrorMessage ="Parola ve parola tekrar alanı eşleşmiyor.")]
        public string PasswordConfirm { get; set; }

        [Display(Name ="Kullanıcı resmi")]
        [UIHint("ImageUpload")]
        public HttpPostedFileBase PostedFile { get; set; }
    }

    public class MatchAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            LoginWithImage instance = validationContext.ObjectInstance as LoginWithImage;
            if (instance.LoginModel.Password != instance.PasswordConfirm)
                return new ValidationResult(ErrorMessage);
            else
                return null;
        }
    }

}
