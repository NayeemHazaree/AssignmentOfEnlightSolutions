using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOfEnlightSolutions_Models.Models
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public int Total_Price { get; set; }
        public int Paid { get; set; }
        public int Due { get; set; }
        public IEnumerable<CustomerItem> Items { get; set; }    
    }
}
