using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Events
    {
        [Key]
        public int EventsID { get; set; }
        public string Time { get; set; }
        public string ENumber { get; set; }
        public string EName { get; set; }
        public int Venue { get; set; }
        public int Role_managmentID { get; set; }
        public virtual Role_managment role_managment { get; set; }

    }
}