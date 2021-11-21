using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Attributes
{
    public class ZipValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            
            if (value is int zip)
            {
                return zip < 1000 && zip < 9999;
            }
            return base.IsValid(value);
        }
    }
}
