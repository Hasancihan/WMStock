using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMStock.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public int LocationID { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }

        public virtual Location Location { get; set; }
    }
}