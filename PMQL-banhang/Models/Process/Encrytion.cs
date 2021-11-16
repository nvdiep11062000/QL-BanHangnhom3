using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PMQL_banhang.Models.Process
{
    public class Encrytion
    {
        
        public string PassWordEncrytion(string pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(),"MD5");
        }
    }
}