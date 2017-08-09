using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KWRT.Database.Models
{
    public class KWRTUser
    {
        public KWRTUser()
        {
            UserId = Guid.NewGuid();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public int CountryId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}