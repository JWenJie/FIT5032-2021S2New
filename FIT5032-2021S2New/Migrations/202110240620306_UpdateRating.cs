namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "Store_Store_id", "dbo.Stores");
            DropIndex("dbo.Ratings", new[] { "Store_Store_id" });
            RenameColumn(table: "dbo.Ratings", name: "Store_Store_id", newName: "Store_id");
            AlterColumn("dbo.Ratings", "Store_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "Store_id");
            AddForeignKey("dbo.Ratings", "Store_id", "dbo.Stores", "Store_id", cascadeDelete: true);
            DropColumn("dbo.Ratings", "StoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "StoreId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ratings", "Store_id", "dbo.Stores");
            DropIndex("dbo.Ratings", new[] { "Store_id" });
            AlterColumn("dbo.Ratings", "Store_id", c => c.Int());
            RenameColumn(table: "dbo.Ratings", name: "Store_id", newName: "Store_Store_id");
            CreateIndex("dbo.Ratings", "Store_Store_id");
            AddForeignKey("dbo.Ratings", "Store_Store_id", "dbo.Stores", "Store_id");
        }
    }
}
