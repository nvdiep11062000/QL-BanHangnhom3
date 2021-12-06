using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMQL_banhang.Models;

namespace PMQL_banhang.Controllers
{
    public class GioHangController : Controller
    {
        private QLbanhangDbContext db = new QLbanhangDbContext();
        [Authorize]
        // GET: GioHang
        public ActionResult Index()
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            return View(giohang);
        }
        //khai báo phương thức thêm sản phẩm vào giỏ hàng
        public RedirectToRouteResult AddToCart (string MaSP)
        {
            if(Session["giohang"] == null)
            {
                Session["giohang"] = new List<GioHang>();
            }
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            //kiểm tra sản phẩm khách đang chọn có trong giỏ hàng chưa
            if(giohang .FirstOrDefault(m => m.MaSP == MaSP)==null)//chưa có trong giỏ hàng 
            {
                SanPham sp = db.SanPhams.Find(MaSP);
                GioHang newItem = new GioHang();
                newItem.MaSP = MaSP;
                newItem.TenSP = sp.TenSP;
                newItem.SoLuong = 1;
                newItem.DonGia = Convert.ToDouble(sp.Dongia);
                giohang.Add(newItem);
            }
            else //sản phẩm đã có trong giỏ hàng,tăng số lượng lên 1
            {
                GioHang gioHang = giohang.FirstOrDefault(m => m.MaSP == MaSP);
                gioHang.SoLuong++;
            }
            Session["giohang"] = giohang;
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Update (string MaSP, int txtSoLuong)
        {
            //tìm sp muốn xóa
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            GioHang item = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if(item != null)
            {
                item.SoLuong = txtSoLuong;
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult Xoagiohang (string MaSP)
        {
            List<GioHang> giohang = Session["giohang"] as List<GioHang>;
            GioHang item = giohang.FirstOrDefault(m => m.MaSP == MaSP);
            if (item != null)
            {
                giohang.Remove(item);
                Session["giohang"] = giohang;
            }
            return RedirectToAction("Index");
        }
    }
}