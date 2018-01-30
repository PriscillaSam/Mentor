using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Models
{
    public class AssignViewModel
    {
        public MenteeModel Mentee { get; set; } = new MenteeModel();
        public MentorModel Mentor { get; set; } = new MentorModel();
        public IEnumerable<SelectListItem> Mentors { get; set; } = new HashSet<SelectListItem>();

       

    }
}