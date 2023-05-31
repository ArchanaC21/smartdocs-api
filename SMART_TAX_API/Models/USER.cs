using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class USER
    {
        public string ID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string EMPLOYEE_CODE { get; set; }
        public string DESIGNATION { get; set; }
        public string EMAIL { get; set; }
        public List<USER_COMPANY> USER_COMPANY { get; set; } = new List<USER_COMPANY>();
        public string ROLE { get; set; }
        public bool? STATUS { get; set; }
    }

    public class USER_COMPANY
    {
        public int ID { get; set; }
        public string NAME { get; set; }
    }

    public class USER_MASTER
    {
        public int ID { get; set; }
        public string PAN { get; set; }
        public string PASSWORD { get; set; }
        public string COMPANY_NAME { get; set; }
        public string ENCRYPT_PASSWORD { get; set; }
        public bool IS_ACTIVE { get; set; }
    }

    
}
