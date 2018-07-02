using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static EvolentPracticeApi.Models.CustomValidation;

namespace EvolentPracticeApi.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "First Name is Must")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Must be Upper Case")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Must")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EmailId is Must")]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        public string EmailId { get; set; }
        
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string Mobile { get; set; }

        [CheckStatus(_allowStatus = "Active,Inactive,ACTIVE,INACTIVE", ErrorMessage = ("Please choose a valid "))]
        public string Status { get; set; }
       
    }
}