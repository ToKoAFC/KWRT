using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureDictionaryType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DictionaryTypeId { get; set; }
        public string Value { get; set; }
    }
}