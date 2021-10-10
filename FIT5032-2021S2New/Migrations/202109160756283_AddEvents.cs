namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Event_id = c.Int(nullable: false, identity: true),
                        Store_id = c.Int(nullable: false),
                        Event_type_id = c.Int(nullable: false),
                        Start_time = c.DateTime(nullable: false),
                        End_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Event_id)
                .ForeignKey("dbo.Event_Type", t => t.Event_type_id, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.Store_id, cascadeDelete: true)
                .Index(t => t.Store_id)
                .Index(t => t.Event_type_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Store_id", "dbo.Stores");
            DropForeignKey("dbo.Events", "Event_type_id", "dbo.Event_Type");
            DropIndex("dbo.Events", new[] { "Event_type_id" });
            DropIndex("dbo.Events", new[] { "Store_id" });
            DropTable("dbo.Events");
        }
    }
}
