using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class ForumModel : ValidatorModel
    {
        public int ForumId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
