namespace PMQL_banhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HoaDon", "NgayGiaoHang", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HoaDon", "NgayGiaoHang", c => c.DateTime());
        }
    }
}
