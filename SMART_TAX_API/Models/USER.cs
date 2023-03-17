using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class USER
    {
        public int ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string DESIGNATION { get; set; }
        public string EMAIL { get; set; }
        public int COMPANY_ID { get; set; }
        public string COMPANY_NAME { get; set; }
        public string ROLE { get; set; }
        public bool? STATUS { get; set; }
    }
}
