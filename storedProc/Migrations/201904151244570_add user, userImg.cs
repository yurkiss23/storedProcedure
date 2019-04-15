namespace storedProc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduseruserImg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.stored_UserImg",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.stored_Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.stored_Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 75),
                        FirstName = c.String(nullable: false, maxLength: 75),
                        LastName = c.String(nullable: false, maxLength: 75),
                        Age = c.Int(nullable: false),
                        Sex = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.stored_UserImg", "UserID", "dbo.stored_Users");
            DropIndex("dbo.stored_UserImg", new[] { "UserID" });
            DropTable("dbo.stored_Users");
            DropTable("dbo.stored_UserImg");
        }
    }
}
