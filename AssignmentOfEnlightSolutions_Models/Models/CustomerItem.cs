using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOfEnlightSolutions_Models.Models
{
    public  class CustomerItem
    {
        public Guid CustomerId;
        public Customer Customer { get; set; }
        public Guid ItemId;
        public Item Item { get; set; }
        public int Quantity;
    }
}
