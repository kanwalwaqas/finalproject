using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Fund_Type
    {
        [Key]
        public string Fund_TypeID { get; set; }
        public string Registration_typeID { get; set; }
        public virtual Registration_type registration_type { get; set; }
        public string Zakat { get; set; }
        public string Sadaqah { get; set; }
        public string Usher { get; set; }
        public string zakat_ul_fitr { get; set; }
        public string khums { get; set; }
        public string Atia_o_Khairat{ get; set; }
        public string status { get; set; }

    }
}