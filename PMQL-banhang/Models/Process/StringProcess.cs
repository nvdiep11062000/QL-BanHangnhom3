using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMQL_banhang.Models.Process
{
    [Table("StringProcesss")]
    public class StringProcess
    {
        [Key]
        public int MyProperty { get; set; }
    }
}