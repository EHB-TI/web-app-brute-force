using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EHikeB.Models
{
    public class CustomerSession
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
