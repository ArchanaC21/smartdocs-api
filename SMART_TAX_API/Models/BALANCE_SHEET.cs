using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class BALANCE_SHEET
    {
        public List<ASSETS> ASSETs { get; set; }
        public List<LIABILITIES> LIABILITYs { get; set; }
    }

    public class ASSETS
    {
        public string ASSET { get; set; }
        public decimal ASSET_AMOUNT { get; set; }
    }

    public class LIABILITIES
    {
        public string LIABILITY { get; set; }
        public decimal LIABILITY_AMOUNT { get; set; }
    }
}
