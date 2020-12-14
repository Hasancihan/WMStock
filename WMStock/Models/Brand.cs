using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Modal> Modals { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}