﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Dtos
{
    public class RentalDTO
    {
       public int CustomerId { get; set; }
       public List<int> MovieIds { get; set; }
    }
}