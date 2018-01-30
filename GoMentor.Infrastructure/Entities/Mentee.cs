using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoMentor.Infrastructure.Entities
{
    public class Mentee
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string MobileNo { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        // Relationships
        public virtual Category Category { get; set; }
        public virtual Mentor Mentor { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();


    }
}