namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBooks2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "Book_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Book_id", c => c.Int(nullable: false));
        }
    }
}
