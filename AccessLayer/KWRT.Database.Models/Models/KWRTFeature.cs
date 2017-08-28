using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeature
    {
        public KWRTFeature()
        {
            Products = new HashSet<KWRTProduct>();
            Modules = new HashSet<KWRTModule>();
            Elements = new HashSet<KWRTFeatureElements>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<KWRTProduct> Products { get; set; }
        public virtual ICollection<KWRTFeatureElements> Elements { get; set; }
        public virtual ICollection<KWRTModule> Modules { get; set; }
    }
}