using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Register
    {
        [Key]
        public int RegisterID { get; set; }
        public int AdminID { get; set; }
        public virtual Admin admin { get; set; }
        public int DonorID { get; set; }
        public virtual Donor donor { get; set; }
        public int ClientID { get; set; }
        public virtual Client client { get; set; }
    }
}