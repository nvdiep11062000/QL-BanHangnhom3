using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PMQL_banhang.Models;

namespace PMQL_banhang.Controllers
{
    public class ChiTietHDsController : Controller
    {
        private QLbanhangDbContext db = new QLbanhangDbContext();

        // GET: ChiTietHDs
        public ActionResult Index()
        {
            var chiTietHDs = db.ChiTietHDs.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(chiTietHDs.ToList());
        }

        // GET: ChiTietHDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // GET: ChiTietHDs/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: ChiTietHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSP,SoLuong,DonGiaBan")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHDs.Add(chiTietHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // GET: ChiTietHDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // POST: ChiTietHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSP,SoLuong,DonGiaBan")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaKH", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // GET: ChiTietHDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: ChiTietHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            db.ChiTietHDs.Remove(chiTietHD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
