﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrid.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string EnName { get; set; }
        public string ArName { get; set; }

        // Navigation TO Proudct
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
