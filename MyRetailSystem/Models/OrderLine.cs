﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MyRetailSystem.Models
{
    public partial class OrderLine
    {
        public int LineId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Qty { get; set; }
        public double TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}