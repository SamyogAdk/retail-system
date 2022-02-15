using System;
using System.Collections.Generic;

#nullable disable

namespace MyRetailSystem.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
