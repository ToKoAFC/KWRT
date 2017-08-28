using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureElements
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FutureElementId { get; set; }
        public int FeatureId { get; set; }
        public int FeatureElementTypeId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual KWRTFeature Feature { get; set; }
        public virtual KWRTFeatureElementType FeatureElementType { get; set; }
    }
}