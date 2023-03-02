using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class ASSESSMENT_YEAR_MASTER
    {
        public int COMPANY_ID { get; set; }
        public string ASSESSMENT_YEAR { get; set; }
        public bool IS_TAX_AUDIT { get; set; }
        public bool IS_TRANSFER_PRICING { get; set; }
        public bool IS_MASTER_FILING { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TA_DUE_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TP_DUE_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime? MF_DUE_DATE { get; set; }
        public string CREATED_BY { get; set; }
        public List<ASSESSMENT_YEAR_DETAILS> NAME_OF_AUDITOR { get; set; } = new List<ASSESSMENT_YEAR_DETAILS>();
        public List<ASSESSMENT_YEAR_DETAILS> CEO { get; set; } = new List<ASSESSMENT_YEAR_DETAILS>();
        public List<ASSESSMENT_YEAR_DETAILS> CFO { get; set; } = new List<ASSESSMENT_YEAR_DETAILS>();
        public List<ASSESSMENT_YEAR_DETAILS> MAIN_BANKER { get; set; } = new List<ASSESSMENT_YEAR_DETAILS>();
        public List<ASSESSMENT_YEAR_DETAILS> DIRECTOR { get; set; } = new List<ASSESSMENT_YEAR_DETAILS>();
    }

    public class ASSESSMENT_YEAR_DETAILS
    {
        public int ASSESSMENT_YEAR_ID { get; set; }
        public string CATEGORY { get; set; }
        public string NAME { get; set; }
        [DataType(DataType.Date)]
        public DateTime FROM_DATE { get; set; }
        [DataType(DataType.Date)]
        public DateTime TO_DATE { get; set; }
        public bool ACTIVE { get; set; }
    }

}
