using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{
    public class Base
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order =1)]
        public int Id { get; set; }


        [ScaffoldColumn(false)]
        [Column(Order =25)]
        public DateTime CreateDate { get; set; }


        [ScaffoldColumn(false)]
        [Column(Order = 26)]
        public DateTime LastupDate { get; set; }

        [Column(TypeName ="varchar",Order =22)]
        [StringLength(27)]
        [ScaffoldColumn(false)]
        public string LastupUser { get; set; }

        [Column(TypeName = "varchar", Order = 23)]
        [StringLength(28)]
        [ScaffoldColumn(false)]
        public string CreateUser { get; set; }

        [Display(Name ="Durumu"),Column(Order =29)]
        public bool IsActive { get; set; }

        public Base()
        {
            IsActive = true;
            CreateDate = DateTime.Now;
            LastupDate = DateTime.Now;
            LastupUser = "admin";
            CreateUser = "admin";
        }
    }
}
