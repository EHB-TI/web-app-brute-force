using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Models
{
    public class DashboardViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Session> Sessions { get; set; }

    }
}
