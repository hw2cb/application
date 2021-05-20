namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Request_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Requests", t => t.Request_Id)
                .Index(t => t.Request_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subjects", "Request_Id", "dbo.Requests");
            DropIndex("dbo.Subjects", new[] { "Request_Id" });
            DropTable("dbo.Subjects");
            DropTable("dbo.Requests");
        }
    }
}
