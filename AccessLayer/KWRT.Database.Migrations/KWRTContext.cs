using KWRT.Database.Models.Models;
using System.Data.Entity;

namespace KWRT.Database.Migrations
{
    public class KWRTContext : DbContext
    {
        public DbSet<KWRTUser> Users { get; set; }
    }
}