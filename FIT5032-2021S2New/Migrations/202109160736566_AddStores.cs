namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Store_id = c.Int(nullable: false, identity: true),
                        Store_name = c.String(nullable: false, maxLength: 20),
                        Store_address = c.String(nullable: false, maxLength: 30),
                        Contact_number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Store_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
        }
    }
}
