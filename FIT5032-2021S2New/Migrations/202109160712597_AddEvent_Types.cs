namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEvent_Types : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Event_Type",
                c => new
                    {
                        Event_type_id = c.Int(nullable: false, identity: true),
                        Event_name = c.String(nullable: false, maxLength: 20),
                        Prize = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Event_type_id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Event_Type");
        }
    }
}
