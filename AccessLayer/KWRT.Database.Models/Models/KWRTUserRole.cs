using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTUserRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }
        public virtual KWRTRole Role { get; set; }
        public virtual KWRTUser User { get; set; }
    }
}