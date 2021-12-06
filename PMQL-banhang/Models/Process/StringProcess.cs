using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace PMQL_banhang.Models.Process
{
    [Table("StringProcesss")]
    public class StringProcess
    {
        public string AutoGenerateKey(string strInput)
        {
            string numPart, strPart, personKey = "", newNumPart = "";
            int intNumber;
            numPart = Regex.Match(strInput, @"\d+").Value;
            intNumber = Convert.ToInt32(numPart) + 1;
            for (int i = 0; i < numPart.Length - intNumber.ToString().Length; i++)
            {
                newNumPart += "0";
            }
            newNumPart += intNumber;
            strPart = numPart = Regex.Match(strInput, @"\D+").Value;
            personKey = strPart + newNumPart;
            return personKey;
        }
    }
}