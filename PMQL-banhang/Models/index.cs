using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMQL_banhang.Models
{
    [Table("indexs")]
    public class index
    {
        [Key]
        public string Name { get; set; }
    }
}