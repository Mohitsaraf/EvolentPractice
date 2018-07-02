using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvolentPracticeApi.Models
{
    public class CustomValidation
    {
        public sealed class CheckStatus : ValidationAttribute
        {
            public String _allowStatus { get; set; }

            protected override ValidationResult IsValid(object status, ValidationContext validationContext)
            {
                string[] myarr = _allowStatus.ToString().Split(',');
                if (myarr.Contains(status)||string.IsNullOrEmpty(status.ToString()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please choose a valid input(Active,Inactive,ACTIVE,INACTIVE)");
                }
            }

        }

    }
}