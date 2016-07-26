using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;
namespace Vidly.Dtos
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
               
        public byte MemberShipTypeId { get; set; }

        public MemberShipTypeDTO MemberShipType{ get; set; }

        //[Min18YearsForMemberShip]
        public DateTime? Birthdate { get; set; }
    }
}