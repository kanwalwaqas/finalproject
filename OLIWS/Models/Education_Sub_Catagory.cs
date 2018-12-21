using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Education_Sub_Catagory
    {
        [Key]
        public int Education_Sub_CatagoryID { get; set; }
        public string Name { get; set; }
        public int EducationCategoryID { get; set; }
        public virtual EducationCategory Education_Cat { get; set; }
    }
}