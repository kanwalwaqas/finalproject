using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Campaigns
    {
        [Key]
        public string CampaignsID { get; set; }
        public string volunteer1 { get; set; }
        public string volunteer2 { get; set; }
        public string volunteer3 { get; set; }
        public string volunteer4 { get; set; }
        public string volunteer5 { get; set; }
        public string volunteer6 { get; set; }
        public string volunteer7 { get; set; }
        public string volunteer8 { get; set; }
        public string volunteer9 { get; set; }
        public string volunteer10 { get; set; }
        public string task { get; set; }
        public string compaign_area { get; set; }
        public string Purpose { get; set; }
        public DateTime date_time { get; set; }
        public string timelimit { get; set; }
        public int status { get; set; }// done ,not done, pandding, 0, 1,2
    }
}