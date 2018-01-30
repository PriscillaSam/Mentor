using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Models
{
    public class MentorSignUpViewModel 
    {

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Category { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}