using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }
        public string your_message { get; set; }
        public string your_name { get; set; }
        public string your_email { get; set; }
        public string your_subj { get; set; }
        public int Role_managmentID { get; set; }
        public virtual Role_managment role_managment { get; set; }
    }
}