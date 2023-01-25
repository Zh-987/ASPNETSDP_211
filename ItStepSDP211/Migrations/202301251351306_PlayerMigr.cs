namespace ItStepSDP211.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Url = c.String(),
                        Order = c.Int(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.ParentId)
                .Index(t => t.ParentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "ParentId", "dbo.MenuItems");
            DropIndex("dbo.MenuItems", new[] { "ParentId" });
            DropTable("dbo.MenuItems");
        }
    }
}
