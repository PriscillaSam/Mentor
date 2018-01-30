using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class MentorModel : ValidatorModel
    {
        public int UserId { get; set; }
        public string MobileNo { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Bio { get; set; }
        public string Category { get; set; }
        public UserModel User { get; set; }
        public ICollection<MenteeModel> Mentees { get; set; }


        public override void Validate()
        {
            base.Validate();
        }
    }
}
