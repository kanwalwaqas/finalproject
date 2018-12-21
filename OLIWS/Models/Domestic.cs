﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Domestic
    {
        [Key]
        public int DomesticID { get; set; }
        public int Online_donationID { get; set; }
        public virtual Online_donation online_donation { get; set; }

    }
}