using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace PMQL_banhang.Models
{
    public partial class QLbanhangDbContext : DbContext
    {
        public QLbanhangDbContext()
            : base("name=QLbanhangDbContext")
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ChiTietHD> ChiTietHDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>()
                .HasOptional(e => e.ChiTietHD)
                .WithRequired(e => e.HoaDon);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoai)
                .IsFixedLength();
        }
    }
}
