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
            
            if (value is string zip)
            {
                try
                {
                    int zipcode = int.Parse(zip);
                    return zipcode < 1000 && zipcode < 9999;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            return base.IsValid(value);
        }
    }
}
