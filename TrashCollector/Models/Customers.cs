using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        //google a date picker
        [Display(Name = "Day of the week for pick up")]
        public string PickUpdate { get; set; }
        

        [Display(Name = "Stop Pick Up Date")]
        public string StopPickUp { get; set; }

        [Display(Name = "Temporarily stop pick up start date")]
        public string TempSuspendStart { get; set; }

        [Display(Name = "Temporarily stop pick up end date")]
        public string TempSuspendEnd { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}