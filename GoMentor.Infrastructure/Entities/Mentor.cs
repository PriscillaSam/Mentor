using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Entities
{
    public class Mentor
    {

        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string MobileNo { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }

        //Relationships
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Mentee> Mentees { get; set; } = new HashSet<Mentee>();

    }
}
