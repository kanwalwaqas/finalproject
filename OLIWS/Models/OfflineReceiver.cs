using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    public class OfflineReceiver
    {
        [Key]
        public int OfflineReceiverID { get; set; }
        public int LocalisedID { get; set; }
        public virtual Localised localised { get; set; }
    }
}