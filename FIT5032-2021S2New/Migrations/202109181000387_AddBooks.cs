namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Book_id = c.Int(nullable: false, identity: true),
                        Event_id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Book_id)
                .ForeignKey("dbo.Events", t => t.Event_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Event_id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Books", "Event_id", "dbo.Events");
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropIndex("dbo.Books", new[] { "Event_id" });
            DropTable("dbo.Books");
        }
    }
}
