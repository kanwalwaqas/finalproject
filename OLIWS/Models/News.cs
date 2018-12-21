using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class News
    {
        [Key]
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public string NewsNumber { get; set; }
        public string IsActive { get; set; }
        public string Date { get; set; }
        public int Role_managmentID { get; set; }
        public virtual Role_managment role_managment { get; set; }


    }
}