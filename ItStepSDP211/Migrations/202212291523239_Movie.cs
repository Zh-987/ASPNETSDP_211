namespace ItStepSDP211.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BuyTickets",
                c => new
                    {
                        BuyTicketsId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Person = c.String(),
                        Price = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BuyTicketsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BuyTickets");
            DropTable("dbo.Movies");
        }
    }
}
