﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTFeatureElementType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeatureElementTypeId { get; set; }
        public string Value { get; set; }
        public bool IsDictionary { get; set; }
    }
}