namespace PMQL_banhang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.updates",
                c => new
                    {
                        MyProperty = c.String(nullable: false, maxLength: 128),
                        MyProperty2 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MyProperty);
            
            DropTable("dbo.StringProcesss");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StringProcesss",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MyProperty);
            
            DropTable("dbo.updates");
        }
    }
}
