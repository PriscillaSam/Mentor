using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Infrastructure.Entities
{
    public class Admin
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }       
        public virtual User User { get; set; }
    }
}
