namespace PMQL_banhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.ChiTietHD",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 50),
                        MaSP = c.String(maxLength: 50),
                        SoLuong = c.Int(),
                        DonGiaBan = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.HoaDon", t => t.MaHD)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaHD)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 50),
                        MaKH = c.String(maxLength: 50),
                        MaNV = c.String(maxLength: 50),
                        NgayLapHD = c.String(maxLength: 50),
                        NgayGiaoHang = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 50),
                        TenKH = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        SDT = c.String(maxLength: 10),
                        Email = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 50),
                        HoNV = c.String(maxLength: 50),
                        Ten = c.String(maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        DienThoai = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 50),
                        TenSP = c.String(maxLength: 50),
                        Donvitinh = c.String(maxLength: 50),
                        Dongia = c.String(maxLength: 50),
                        MaLoaiSP = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSP", t => t.MaLoaiSP)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        MaLoaiSP = c.String(nullable: false, maxLength: 50),
                        TenLoaiSP = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.ChiTietHD", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.HoaDon", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.HoaDon", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietHD", "MaHD", "dbo.HoaDon");
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.HoaDon", new[] { "MaNV" });
            DropIndex("dbo.HoaDon", new[] { "MaKH" });
            DropIndex("dbo.ChiTietHD", new[] { "MaSP" });
            DropIndex("dbo.ChiTietHD", new[] { "MaHD" });
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.LoaiSP");
            DropTable("dbo.SanPham");
            DropTable("dbo.NhanVien");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.ChiTietHD");
            DropTable("dbo.Accounts");
        }
    }
}
