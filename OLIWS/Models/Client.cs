using System;
using System.ComponentModel.DataAnnotations;

namespace OLIWS.Models
{
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string CNIC { get; set; }
        public string Area { get; set; }
        public DateTime Date_of_birth { get; set; }
        public string email { get; set; }
        public string pasword { get; set; }
        public string confirmpasword{ get; set; }



    }
}