namespace FIT5032_2021S2New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStudents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropColumn("dbo.Books", "UserId");
            RenameColumn(table: "dbo.Books", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Books", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Books", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Books", "UserId");
            AddForeignKey("dbo.Books", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "UserId" });
            AlterColumn("dbo.Books", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Books", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Books", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Books", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "User_Id");
            AddForeignKey("dbo.Books", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
