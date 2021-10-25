namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBooks1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Book_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", new[] { "Event_id", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Books", "Book_id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Book_id");
        }
    }
}
