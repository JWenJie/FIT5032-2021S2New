namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBooks4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Books", newName: "BookEvents");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BookEvents", newName: "Books");
        }
    }
}
