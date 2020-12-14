using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

    }
}