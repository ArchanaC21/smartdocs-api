using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class SYSTEM_TYPE_MASTER
    {
        public int ID { get; set; }
        public string CATEGORY { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public bool? STATUS { get; set; }
    }
}
