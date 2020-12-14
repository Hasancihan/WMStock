using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Inventory

    {

        public int InventoryID { get; set; }

        public string InventoryName { get; set; }

        public int PersonalID { get; set; }

        public int LocationID { get; set; }

        public int CategoryID { get; set; }
        public int BrandID { get; set; }
        public int ModalID { get; set; }

        public DateTime DateTime { get; set; }


        public virtual Personal Personal { get; set; }

        public virtual Location Location { get; set; }

        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Modal Modal { get; set; }

        


        

    }
}