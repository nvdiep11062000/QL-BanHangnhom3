using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMQL_banhang.Models
{
    [Table("GioHangs")]
    public class GioHang
    {
        [Key]
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { 
            get { return SoLuong * DonGia; }
                }
    }
}