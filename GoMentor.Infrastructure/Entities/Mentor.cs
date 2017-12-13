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
        public string City { get; set; }
        public string State { get; set; }
        public string MobileNo { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Mentee> Mentees { get; set; } = new HashSet<Mentee>();
        public virtual User User { get; set; }

    }
}
