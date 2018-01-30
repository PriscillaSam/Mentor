using GoMentor.Domain.Models;
using GoMentor.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoMentor.Web.Models
{
    public class SignupViewModel : ValidatorModel
    {

        [EmailAddress, Required]
        public string Email { get; set; }

        [Required, Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, DataType(DataType.Password), MinLength(7, ErrorMessage = "Password must be at least 7 characters")]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("Passwords do not match", new[] { nameof(Password), nameof(ConfirmPassword) });
            }
        }

    }
}