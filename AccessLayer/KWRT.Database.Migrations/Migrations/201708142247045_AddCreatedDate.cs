namespace KWRT.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KWRTFeatures", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.KWRTProducts", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.KWRTProducts", "CreatedDate");
            DropColumn("dbo.KWRTFeatures", "CreatedDate");
        }
    }
}
