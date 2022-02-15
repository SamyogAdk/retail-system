using System;
using System.Collections.Generic;

#nullable disable

namespace MyRetailSystem.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
