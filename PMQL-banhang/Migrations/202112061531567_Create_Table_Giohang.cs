namespace PMQL_banhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Giohang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 128),
                        TenSP = c.String(),
                        DonGia = c.Double(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSP);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GioHangs");
        }
    }
}
