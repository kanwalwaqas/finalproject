using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class team_asigned_jobs
    {
        [Key]
        public string tm_job_Id { get; set; }
        public int Job_status { get; set; }  //0,1,2
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string TeamID { get; set; }
        public virtual Team team { get; set; }
        public DateTime currentdate { get; set; }
        public team_asigned_jobs()
        {
            currentdate = DateTime.Now;
        }

    }
}