namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewArchBd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestSubjects", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.RequestSubjects", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.RequestSubjects", new[] { "Request_Id" });
            DropIndex("dbo.RequestSubjects", new[] { "Subject_Id" });
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Subject_Id = c.Int(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Request_Id);
            
            DropColumn("dbo.Requests", "Quantity");
            DropColumn("dbo.Requests", "Description");
            DropColumn("dbo.Requests", "SubjId");
            DropColumn("dbo.Requests", "Count");
            DropTable("dbo.RequestSubjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RequestSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Request_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Requests", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "SubjId", c => c.Int(nullable: false));
            AddColumn("dbo.Requests", "Description", c => c.String());
            AddColumn("dbo.Requests", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "Request_Id", "dbo.Requests");
            DropForeignKey("dbo.Items", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.Items", new[] { "Request_Id" });
            DropIndex("dbo.Items", new[] { "Subject_Id" });
            DropTable("dbo.Items");
            CreateIndex("dbo.RequestSubjects", "Subject_Id");
            CreateIndex("dbo.RequestSubjects", "Request_Id");
            AddForeignKey("dbo.RequestSubjects", "Subject_Id", "dbo.Subjects", "Id");
            AddForeignKey("dbo.RequestSubjects", "Request_Id", "dbo.Requests", "Id");
        }
    }
}
