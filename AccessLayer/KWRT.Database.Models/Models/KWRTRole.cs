using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models.Models
{
    public class KWRTRole
    {
        public KWRTRole()
        {
            RoleId = Guid.NewGuid();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }

        public string Name { get; set; }
    }
}