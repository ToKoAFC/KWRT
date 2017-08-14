namespace KWRT.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeatures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KWRTFeatures",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.KWRTProductKWRTFeatures",
                c => new
                    {
                        KWRTProduct_ProductId = c.Int(nullable: false),
                        KWRTFeature_FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KWRTProduct_ProductId, t.KWRTFeature_FeatureId })
                .ForeignKey("dbo.KWRTProducts", t => t.KWRTProduct_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.KWRTFeatures", t => t.KWRTFeature_FeatureId, cascadeDelete: true)
                .Index(t => t.KWRTProduct_ProductId)
                .Index(t => t.KWRTFeature_FeatureId);
            
            DropColumn("dbo.KWRTProducts", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KWRTProducts", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.KWRTProductKWRTFeatures", "KWRTFeature_FeatureId", "dbo.KWRTFeatures");
            DropForeignKey("dbo.KWRTProductKWRTFeatures", "KWRTProduct_ProductId", "dbo.KWRTProducts");
            DropIndex("dbo.KWRTProductKWRTFeatures", new[] { "KWRTFeature_FeatureId" });
            DropIndex("dbo.KWRTProductKWRTFeatures", new[] { "KWRTProduct_ProductId" });
            DropTable("dbo.KWRTProductKWRTFeatures");
            DropTable("dbo.KWRTFeatures");
        }
    }
}
