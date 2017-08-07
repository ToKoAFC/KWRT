namespace KWRT.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRole : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KWRTRoles",
                c => new
                    {
                        RoleId = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.KWRTUserRoles",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        RoleId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.KWRTRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.KWRTUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.KWRTUsers",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        SecondName = c.String(maxLength: 256),
                        Surname = c.String(maxLength: 50),
                        CountryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KWRTUserRoles", "UserId", "dbo.KWRTUsers");
            DropForeignKey("dbo.KWRTUserRoles", "RoleId", "dbo.KWRTRoles");
            DropIndex("dbo.KWRTUserRoles", new[] { "UserId" });
            DropIndex("dbo.KWRTUserRoles", new[] { "RoleId" });
            DropTable("dbo.KWRTUsers");
            DropTable("dbo.KWRTUserRoles");
            DropTable("dbo.KWRTRoles");
        }
    }
}
