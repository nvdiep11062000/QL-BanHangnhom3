using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMQL_banhang.Models
{
    [Table("updates")]
    public class update
    {
        [Key]
        public string MyProperty { get; set; }
        public int MyProperty2 { get; set; }
    }
}