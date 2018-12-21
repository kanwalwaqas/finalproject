using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public string Date { get; set; }
        public int Role_managmentID { get; set; }
        public virtual Role_managment role_managment { get; set; }


    }
}