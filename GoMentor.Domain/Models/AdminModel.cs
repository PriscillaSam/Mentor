using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class AdminModel : ValidatorModel
    {
        public int UserId { get; set; }
        public UserModel User { get; set; }

    }
}
