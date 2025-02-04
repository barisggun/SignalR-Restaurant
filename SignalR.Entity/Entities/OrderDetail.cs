﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Entity.Entities
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }  
        public int UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Order Order { get; set; }
    }
}
