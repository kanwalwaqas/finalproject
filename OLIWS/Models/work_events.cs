using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class work_events
    {
        [Key]
        public string work_eventsID { get; set; }
        public string events { get; set; }
        public string campigns { get; set; }
        public string news { get; set; }
        public string notification { get; set; }
        public bool IsActive { get; set; }


    }
}