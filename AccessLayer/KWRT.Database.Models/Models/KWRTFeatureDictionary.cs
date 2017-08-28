using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureDictionary
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureDictionaryId { get; set; }

        public int FeatureElementTypeId { get; set; }
        public string Value { get; set; }
        public int DictionaryTypeId { get; set; }

        public virtual KWRTFeatureElementType FeatureElementType { get; set; }
        public virtual KWRTFeatureDictionaryType DictionaryType { get; set; }
    }
}