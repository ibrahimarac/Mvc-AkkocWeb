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
    public class SliderWithImage
    {
        public Slider Slider { get; set; }

        [Display(Name ="Resim Seçiniz")]
        [UIHint("ImageUpload")]
        public HttpPostedFileBase SliderImage { get; set; }
    }
}
