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
    public class ProductWithImage
    {
        public Product ProductModel { get; set; }

        [UIHint("ImageUpload")]
        public HttpPostedFileBase ProductImage { get; set; }
    }
}
