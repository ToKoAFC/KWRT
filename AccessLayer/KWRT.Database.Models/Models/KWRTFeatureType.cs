using KWRT.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureTypeId { get; set; }
        public FeatureTypeEnum Type { get; set; }        
    }
}