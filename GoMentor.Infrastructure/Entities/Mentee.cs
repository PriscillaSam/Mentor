using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoMentor.Infrastructure.Entities
{
    public class Mentee
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }       
        public string CIty { get; set; }
        public string State { get; set; }
        public string PersonalInfo { get; set; }
        public int MentorId { get; set; }
        public virtual Mentor Mentor { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
       
        
        }
}