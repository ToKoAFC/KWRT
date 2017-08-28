using KWRT.Database.Models;
using System.Data.Entity;

namespace KWRT.Database.Migrations
{
    public class KWRTContext : DbContext
    {
        public DbSet<KWRTUser> Users { get; set; }
        public DbSet<KWRTRole> Roles { get; set; }
        public DbSet<KWRTUserRole> UserRoles { get; set; }
        public DbSet<KWRTProduct> Products { get; set; }
        public DbSet<KWRTFeature> Features { get; set; }
        public DbSet<KWRTFeatureDictionary> FeatureDictionaries { get; set; }
        public DbSet<KWRTFeatureDictionaryType> FeatureDictionaryTypes { get; set; }
        public DbSet<KWRTFeatureElements> FeatureElements { get; set; }
        public DbSet<KWRTFeatureElementType> FeatureElementTypes { get; set; }
        public DbSet<KWRTModule> Modules { get; set; }
    }
}