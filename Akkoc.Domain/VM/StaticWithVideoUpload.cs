using Akkoc.Domain.POCO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Akkoc.Domain.VM
{
    public class StaticWithVideoUpload
    {
        public Static StaticModel { get; set; }

        [Display(Name ="Video dosyası")]
        [UIHint("FileUpload")]
        public HttpPostedFileBase PostedFile { get; set; }

        [Display(Name = "Logo resmi")]
        [UIHint("ImageUpload")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}
