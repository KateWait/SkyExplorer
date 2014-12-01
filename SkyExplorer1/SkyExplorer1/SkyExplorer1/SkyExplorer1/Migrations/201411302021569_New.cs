namespace SkyExplorer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.User", new[] { "Attachment_AttachmentID" });
            DropIndex("dbo.User", new[] { "ConnectionString_ConnectionStringID" });
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Login", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.User", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.User", "CityName", c => c.String(nullable: false));
            CreateIndex("dbo.ConnectionString", "ConnectionString_ConnectionStringID");
            DropColumn("dbo.User", "PostalCode");
            DropColumn("dbo.User", "Attachment_AttachmentID");
            DropColumn("dbo.User", "ConnectionString_ConnectionStringID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "ConnectionString_ConnectionStringID", c => c.Int());
            AddColumn("dbo.User", "PostalCode", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "CityName", c => c.String());
            AlterColumn("dbo.User", "Street", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Login", c => c.String());
            AlterColumn("dbo.User", "Email", c => c.String());
            AlterColumn("dbo.User", "Surname", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            CreateIndex("dbo.User", "ConnectionString_ConnectionStringID");
        }
    }
}
