using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OLIWS.Models
{
    [Serializable]
    public class DonorViewModel
    {
        public string Zakat { get; set; }
        public string Sadaqah { get; set; }
        public string Usher { get; set; }
        public string zakat_ul_fitr { get; set; }
        public string khums { get; set; }
        public string Atia_o_Khairat { get; set; }
        public string frequency { get; set; }
        public string Education { get; set; }
        public string Health { get; set; }
        public string Other { get; set; }
        public string Amount { get; set; }
        public string AccountName { get; set; }
        public string duration { get; set; }
        public string AccountNumber { get; set; }
       
        public string SortCode { get; set; }
    }
}