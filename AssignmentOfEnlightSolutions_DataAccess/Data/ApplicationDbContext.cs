using AssignmentOfEnlightSolutions_Models;
using AssignmentOfEnlightSolutions_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOfEnlightSolutions_DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Item { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerItem> CustomersItem { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.Entity<CustomerItem>().HasKey(x => new { x.CustomerId,x.ItemId});
            Builder.Entity<CustomerItem>().HasOne<Customer>(x => x.Customer).WithMany(x => x.Items).HasForeignKey(x => x.CustomerId);
            Builder.Entity<CustomerItem>().HasOne<Item>(x => x.Item).WithMany(x=>x.customers).HasForeignKey(x => x.ItemId);
        }
    }
}
