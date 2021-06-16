using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{

    [Table("ChangeLog")]
    public class ChangeLog:Base
    {
        [Column(TypeName = "int",Order =2)]
        public EntityState Status { get; set; }

        [Column(TypeName ="varchar",Order =3)]
        [StringLength(30)]
        public string EntityName { get; set; }

        [Column(TypeName = "int",Order =4)]
        public int RecordId { get; set; }
    }
}
