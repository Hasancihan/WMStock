using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Modal
    {
        public int ModalID{ get; set; }

        public string ModalName { get; set; }

        public int CategoryID { get; set; }

        public int BrandID { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }

        
    }
}