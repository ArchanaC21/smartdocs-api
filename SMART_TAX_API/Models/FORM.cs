using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class FORM
    {
        public int SECTION_ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string MIDDLE_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string GENDER { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DATE_OF_BIRTH { get; set; }
        public string DESIGNATION { get; set; }
        public string FLAT { get; set; }
        public string NAME_OF_PREMISES { get; set; }
        public string ROAD { get; set; }
        public string AREA { get; set; }
        public string TOWN { get; set; }
        public string STATE { get; set; }
        public string PIN_CODE { get; set; }
        public string EMAIL_ADDRESS { get; set; }
        public string PHONE_NO { get; set; }
        public string MOBILE_NO { get; set; }
        public string RESIDENT_TYPE { get; set; }
        public string STATUS { get; set; }
        public List<PARTB_FORM> PARTB_FORM { get; set; } = new List<PARTB_FORM>();
        public List<PARTC_FORM> PARTC_FORM { get; set; } = new List<PARTC_FORM>();
        public string NAME_OF_PARTY { get; set; }
        public string ADDRESS_OF_PARTY { get; set; }
        public string PAN_OF_PARTY { get; set; }
        public string PARTICULARS_OF_ASSET { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EXPECTED_DATE_OF_TRANSFER { get; set; }
        public string PERIOD { get; set; }
        public string ADDITIONAL_INFO { get; set; }
        public string NATURE_OF_TRANSACTION { get; set; }
        public string ASSESSEE_OUTSTANDING_DEMAND { get; set; }
        public string IS_CIR_CIBIL_AVAILABLE { get; set; }
    }

    public class PARTB_FORM
    {
        public int ID { get; set; }
        public int SECTION_ID { get; set; }
        public int ASSESSMENT_YEAR { get; set; } 
        public string DEMAND_SECTION { get; set; }
        public decimal OUTSTANDING_DEMAND { get; set; }
        public string PARTICULARS_OF_STAY { get; set; }
        public string REMARKS { get; set; }
    }

    public class PARTC_FORM
    {
        public int ID { get; set; }
        public int SECTION_ID { get; set; }
        public string ASSET_DESCRIPTION { get; set; }
        public string PARTICULARS_OF_PLACE { get; set; }
        public string VALUE_OF_THE_ASSET { get; set; }
        public string IS_CHARGE_EXISTS { get; set; }
        public string REMARKS { get; set; }
    }

    
}
