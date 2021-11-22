using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Attributes
{
    public class PlateValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string naam)
            {
                if(naam.Length == 9)
                {
                    return char.IsDigit(naam[0]) && naam[1] == '-' && naam[5] == '-' && char.IsLetter(naam[2])
                    && char.IsLetter(naam[3]) && char.IsLetter(naam[4]) && char.IsDigit(naam[6]) && char.IsDigit(naam[7]) && char.IsDigit(naam[8]);

                }

            }

            return false;
        }
    }
}
