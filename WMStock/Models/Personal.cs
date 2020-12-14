using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WMStock.Models
{
    public class Personal
    {
        public int PersonalId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public string Pjob { get; set; }

        public int DepartmentID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }

   public virtual Department Department { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}