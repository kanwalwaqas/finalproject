using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Contact_us
    {
        [Key]
        public string Contact_usID { get; set; }
        [DisplayName("Name")]
        public string name { get; set; }
        public string lastname { get; set; }
        [DisplayName("Email")]
        public string con_Email { get; set; }
        [DisplayName("Subject")]
        public string subject { get; set; }
        public string Message { get; set; }
        public string status { get; set; }
        public string cont_img { get; set; }
        public bool delete { get; set; }
        public DateTime currentDate { get; set; }
        public Contact_us()
        {
            currentDate = DateTime.Now;

        }
        public bool Seen { get; set; }
        public bool reply { get; set; }
        public string Replied_By { get; set; }
        public string Seen_By { get; set; }

    }
}