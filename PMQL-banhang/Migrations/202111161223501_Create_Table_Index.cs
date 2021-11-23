namespace PMQL_banhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_Index : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.indexs",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.StringProcesss",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StringProcesss");
            DropTable("dbo.indexs");
        }
    }
}
