namespace KWRT.Database.Models
{
    public class KWRTFeatureTypeValue
    {        
        public int TypeId { get; set; }
        public string Value { get; set; }
        
        public virtual KWRTFeatureType Type { get; set; }
    }
}