using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akkoc.Domain.POCO
{
    [Table("LogErrors")]
    public class LogError:Base
    {
        [Column(TypeName ="int",Order =2)]
        public int RecId { get; set; }

        [Column(TypeName ="varchar",Order =3)]
        [StringLength(150)]
        public string EntityName { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(255)]
        public string Message { get; set; }

        [Column(TypeName = "varchar",Order =4)]
        [StringLength(30)]
        public string ControllerName { get; set; }

        [Column(TypeName = "varchar",Order =5)]
        [StringLength(30)]
        public string ActionName { get; set; }

        [Column(Order =6)]
        public bool IsAjaxRequest { get; set; }

    }
}
