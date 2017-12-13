using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Entities
{
   public class Forum
    {
        [Key]
        public int ForumId { get; set; }
        public DateTime DateCreated { get; set; }
        public int MenteeId { get; set; }        
        public virtual Mentee Mentee { get; set; }

    }
}
