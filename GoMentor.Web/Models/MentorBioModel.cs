using GoMentor.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoMentor.Web.Models
{
    public class MentorBioModel
    {
        public UserModel User { get; set; } = new UserModel();

        [Required]
        [Display(Name = "Telephone")]
        public string MobileNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Bio { get; set; }
    }
}