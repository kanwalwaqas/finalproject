using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class work_sub_cat
    {
        [Key]
        public string work_sub_catID { get; set; }
        public string work_eventsID { get; set; }
        public virtual work_events work_event { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string detail { get; set; }
        public string Venue { get; set; }
        public string event_image { get; set; }
    }
}