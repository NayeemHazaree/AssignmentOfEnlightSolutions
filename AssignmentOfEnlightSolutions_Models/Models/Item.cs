using AssignmentOfEnlightSolutions_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOfEnlightSolutions_Models
{
    public class Item
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public double Price { get; set; }
        public IEnumerable<CustomerItem>customers { get; set; }
    }
}
