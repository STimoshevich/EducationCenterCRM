using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EducationCenterCRM.DAL.Entities.ValidationAttributes
{
    public class AgeAttribute : ValidationAttribute
    {
        private readonly int minAge;
        private readonly int maxAge;

        public AgeAttribute(int minAge, int maxAge, string errorMessage) : base(errorMessage)
        {
            this.minAge = minAge;
            this.maxAge = maxAge;
        }

        public override bool IsValid(object value)
        {
            if(value is DateTime)
            {
                var age = ((DateTime.Now - (DateTime)value).TotalDays / 365);
                if (age < maxAge && age > minAge)
                    return true;
            }
            return false;
           
        }
    }
}
