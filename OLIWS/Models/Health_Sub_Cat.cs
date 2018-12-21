using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Health_Sub_Cat
    {
        [Key]
        public int Health_Sub_CatID { get; set; }
        public string Name { get; set; }
        public int EducationCategoryID { get; set; }
        public virtual EducationCategory Education_Cat { get; set; }
    }
}