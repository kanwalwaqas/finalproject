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
     
        public int DonorID { get; set; }
        public virtual Donor donor { get; set; }
        public int ReceiverID { get; set; }
        public virtual Receiver reciever { get; set; }
    }
}