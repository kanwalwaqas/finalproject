using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Organization
    {
        [Key]
        public string OrganizationID { get; set; }
        public string owner_Name { get; set; }
        public string owner_LastName { get; set; }
        public string owner_CNIC { get; set; }
        public string owner_Address { get; set; }
        public string owner_PhoneNum { get; set; }
        public string owner_Email { get; set; }
        public string focalPerson_Name { get; set; }
        public string focalPerson_Num { get; set; }
        public string focalPerson_Address { get; set; }
        public string Id { get; set; }
        public virtual ApplicationUser Users { get; set; }

    }
}