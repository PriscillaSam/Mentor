using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoMentor.Web.Models
{
    public class MentorProfileViewModel
    {
        public MentorModel Mentor { get; set; }
        public IEnumerable<MenteeModel> Mentees { get; set; } = new HashSet<MenteeModel>();
    }
}