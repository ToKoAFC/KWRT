using System.Runtime.Serialization;

namespace KWRT.Common.Enums
{
    public enum FeatureTypeEnum
    {
        [DataMember]
        Int = 1,
        [DataMember]
        String = 2,
        [DataMember]
        DateTime = 3,
        [DataMember]
        Bool = 4,
        [DataMember]
        List = 5
    }
}
