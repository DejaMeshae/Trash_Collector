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

        [Display(Name = "Start Pick-Up Services Date")]
        public DateTime StartPickUp { get; set; }

        [Display(Name = "Day Of The Week For Pick Up")]
        public string PickUpdate { get; set; }

        [Display(Name = "End Pick-Up Services Date")]
        public DateTime StopPickUp { get; set; }

        [Display(Name = "Temporarily Stop Services Start Date")]
        public DateTime TempSuspendStart { get; set; }

        [Display(Name = "Temporarily Stop Services End date")]
        public DateTime TempSuspendEnd { get; set; }

        [Display(Name = "One Time Pick-Up Request Date")]
        public DateTime OneTimePickUpDate { get; set; }

        [Display(Name = "Payment Due: $80")]
        public string BillAmount { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}