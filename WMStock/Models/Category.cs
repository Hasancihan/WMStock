using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }



        public virtual ICollection<Inventory> Inventories { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        public virtual ICollection<Modal> Modals { get; set; }
    }
}