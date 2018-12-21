using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class Localised
    {
        [Key]
        public int LocalisedID { get; set; }
        public string ReceiverNo { get; set; }
        public string AccountType { get; set; }
        public int Fund_CategoriesID { get; set; }
        public virtual Fund_Categories fund_Categories { get; set; }

    }
}