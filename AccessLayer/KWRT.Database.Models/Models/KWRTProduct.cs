using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTProduct
    {
        public KWRTProduct()
        {
            Features = new HashSet<KWRTFeature>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
                
        public bool IsDelete { get; set; }

        public virtual ICollection<KWRTFeature> Features { get; set; }

    }
}