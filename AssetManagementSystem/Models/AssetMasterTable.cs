using System;
using System.Collections.Generic;

namespace AssetManagementSystem.Models
{
    public partial class AssetMasterTable
    {
        public int AmId { get; set; }
        public string AmAtypeId { get; set; }
        public string AmMake { get; set; }
        public string AmAd { get; set; }
        public string AmModel { get; set; }
        public string AmSnumber { get; set; }
        public string AmMyyear { get; set; }
        public DateTime? AmPdate { get; set; }
        public string AmWarranty { get; set; }
        public DateTime? AmFrom { get; set; }
        public DateTime? AmTo { get; set; }
    }
}
