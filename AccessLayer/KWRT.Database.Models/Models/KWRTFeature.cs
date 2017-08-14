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
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<KWRTProduct> Products { get; set; }
    }
}