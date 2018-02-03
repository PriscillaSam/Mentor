using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Models
{
    public class UserModel : ValidatorModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Image { get; set; }

        public string Name => $"{FirstName}, {LastName}";

        public override void Validate()
        {
            base.Validate();
        }
    }


}
