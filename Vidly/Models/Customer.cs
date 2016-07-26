using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage="Please enter the name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MemberShipType MemberShipType { get; set; }

        [Display(Name="Membership Type")]
        public byte MemberShipTypeId { get; set; }

    
        [Display(Name="Date Of Birth")]
        [Min18YearsForMemberShip]
        public DateTime? Birthdate { get; set; }
    }
}