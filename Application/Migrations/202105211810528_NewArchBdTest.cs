namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewArchBdTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Items", new[] { "Subject_Id" });
            RenameColumn(table: "dbo.Items", name: "Subject_Id", newName: "SubjectId");
            AlterColumn("dbo.Items", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Items", "SubjectId");
            AddForeignKey("dbo.Items", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Items", new[] { "SubjectId" });
            AlterColumn("dbo.Items", "SubjectId", c => c.Int());
            RenameColumn(table: "dbo.Items", name: "SubjectId", newName: "Subject_Id");
            CreateIndex("dbo.Items", "Subject_Id");
            AddForeignKey("dbo.Items", "Subject_Id", "dbo.Subjects", "Id");
        }
    }
}
