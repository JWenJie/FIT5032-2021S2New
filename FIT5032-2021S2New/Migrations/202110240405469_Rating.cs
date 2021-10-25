namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        StoreId = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                        Comment = c.String(),
                        Store_Store_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Store_id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Store_Store_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "Store_Store_id", "dbo.Stores");
            DropIndex("dbo.Ratings", new[] { "Store_Store_id" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropTable("dbo.Ratings");
        }
    }
}
