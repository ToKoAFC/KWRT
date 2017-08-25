using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureValue
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }

        public virtual KWRTFeature Feature { get; set; }
        public virtual KWRTFeatureType Type { get; set; }
    }
}