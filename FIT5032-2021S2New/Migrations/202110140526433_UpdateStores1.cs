namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStores1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Stores", "Store_address", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Store_address", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
