namespace KWRT.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KWRTFeatureDictionaries",
                c => new
                    {
                        FeatureDictionaryId = c.Int(nullable: false, identity: true),
                        FeatureElementTypeId = c.Int(nullable: false),
                        Value = c.String(),
                        DictionaryTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureDictionaryId)
                .ForeignKey("dbo.KWRTFeatureDictionaryTypes", t => t.DictionaryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.KWRTFeatureElementTypes", t => t.FeatureElementTypeId, cascadeDelete: true)
                .Index(t => t.FeatureElementTypeId)
                .Index(t => t.DictionaryTypeId);
            
            CreateTable(
                "dbo.KWRTFeatureDictionaryTypes",
                c => new
                    {
                        DictionaryTypeId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.DictionaryTypeId);
            
            CreateTable(
                "dbo.KWRTFeatureElementTypes",
                c => new
                    {
                        FeatureElementTypeId = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        IsDictionary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureElementTypeId);
            
            CreateTable(
                "dbo.KWRTFeatureElements",
                c => new
                    {
                        FutureElementId = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(nullable: false),
                        FeatureElementTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FutureElementId)
                .ForeignKey("dbo.KWRTFeatures", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.KWRTFeatureElementTypes", t => t.FeatureElementTypeId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.FeatureElementTypeId);
            
            CreateTable(
                "dbo.KWRTFeatures",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureId);
            
            CreateTable(
                "dbo.KWRTModules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ModuleId);
            
            CreateTable(
                "dbo.KWRTProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
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
            
            CreateTable(
                "dbo.KWRTModuleKWRTFeatures",
                c => new
                    {
                        KWRTModule_ModuleId = c.Int(nullable: false),
                        KWRTFeature_FeatureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KWRTModule_ModuleId, t.KWRTFeature_FeatureId })
                .ForeignKey("dbo.KWRTModules", t => t.KWRTModule_ModuleId, cascadeDelete: true)
                .ForeignKey("dbo.KWRTFeatures", t => t.KWRTFeature_FeatureId, cascadeDelete: true)
                .Index(t => t.KWRTModule_ModuleId)
                .Index(t => t.KWRTFeature_FeatureId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KWRTUserRoles", "UserId", "dbo.KWRTUsers");
            DropForeignKey("dbo.KWRTUserRoles", "RoleId", "dbo.KWRTRoles");
            DropForeignKey("dbo.KWRTFeatureElements", "FeatureElementTypeId", "dbo.KWRTFeatureElementTypes");
            DropForeignKey("dbo.KWRTProductKWRTFeatures", "KWRTFeature_FeatureId", "dbo.KWRTFeatures");
            DropForeignKey("dbo.KWRTProductKWRTFeatures", "KWRTProduct_ProductId", "dbo.KWRTProducts");
            DropForeignKey("dbo.KWRTModuleKWRTFeatures", "KWRTFeature_FeatureId", "dbo.KWRTFeatures");
            DropForeignKey("dbo.KWRTModuleKWRTFeatures", "KWRTModule_ModuleId", "dbo.KWRTModules");
            DropForeignKey("dbo.KWRTFeatureElements", "FeatureId", "dbo.KWRTFeatures");
            DropForeignKey("dbo.KWRTFeatureDictionaries", "FeatureElementTypeId", "dbo.KWRTFeatureElementTypes");
            DropForeignKey("dbo.KWRTFeatureDictionaries", "DictionaryTypeId", "dbo.KWRTFeatureDictionaryTypes");
            DropIndex("dbo.KWRTProductKWRTFeatures", new[] { "KWRTFeature_FeatureId" });
            DropIndex("dbo.KWRTProductKWRTFeatures", new[] { "KWRTProduct_ProductId" });
            DropIndex("dbo.KWRTModuleKWRTFeatures", new[] { "KWRTFeature_FeatureId" });
            DropIndex("dbo.KWRTModuleKWRTFeatures", new[] { "KWRTModule_ModuleId" });
            DropIndex("dbo.KWRTUserRoles", new[] { "UserId" });
            DropIndex("dbo.KWRTUserRoles", new[] { "RoleId" });
            DropIndex("dbo.KWRTFeatureElements", new[] { "FeatureElementTypeId" });
            DropIndex("dbo.KWRTFeatureElements", new[] { "FeatureId" });
            DropIndex("dbo.KWRTFeatureDictionaries", new[] { "DictionaryTypeId" });
            DropIndex("dbo.KWRTFeatureDictionaries", new[] { "FeatureElementTypeId" });
            DropTable("dbo.KWRTProductKWRTFeatures");
            DropTable("dbo.KWRTModuleKWRTFeatures");
            DropTable("dbo.KWRTUsers");
            DropTable("dbo.KWRTUserRoles");
            DropTable("dbo.KWRTRoles");
            DropTable("dbo.KWRTProducts");
            DropTable("dbo.KWRTModules");
            DropTable("dbo.KWRTFeatures");
            DropTable("dbo.KWRTFeatureElements");
            DropTable("dbo.KWRTFeatureElementTypes");
            DropTable("dbo.KWRTFeatureDictionaryTypes");
            DropTable("dbo.KWRTFeatureDictionaries");
        }
    }
}
