using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class COMPANY
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string FORMER_NAME { get; set; }
        public string SHORT_NAME { get; set; }
        public string PAN { get; set; }
        public DateTime? DATE_OF_INCORPORATION { get; set; }
        public string STATUS { get; set; }
        public string ADDRESS { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string PIN { get; set; }
        public string LANDLINE_NO_1 { get; set; }
        public string LANDLINE_NO_2 { get; set; }
        public string MOBILE_NO_1 { get; set; }
        public string MOBILE_NO_2 { get; set; }
        public string EMAIL_ID_1 { get; set; }
        public string EMAIL_ID_2 { get; set; }
        public string NATURE_OF_BUSINESS { get; set; }
        public string INCOME_TAX_WARD { get; set; }
        public string NAME_OF_STATUTORY_AUDITOR { get; set; }
        public string CEO { get; set; }
        public string CFO { get; set; }
        public string OTHER_CONTACT_PERSON { get; set; }
        public string MAIN_BANKER { get; set; }
        public string VERTICALS { get; set; }
        

    }

    public class COMPANY_VERTICALS
    {
        public int ID { get; set; }
        public string NAME { get; set; }
    }
}
