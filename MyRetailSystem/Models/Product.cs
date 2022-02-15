using System;
using System.Collections.Generic;

#nullable disable

namespace MyRetailSystem.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public string ProductName { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
