using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class EducationCategory
    {
        [Key]
        public int EducationCategoryID { get; set; }
        public string Name { get; set; }
        public int Fund_CategoriesID { get; set; }
        public virtual Fund_Categories Fund { get; set; }

    }
}