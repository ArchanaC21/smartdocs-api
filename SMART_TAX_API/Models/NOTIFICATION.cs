using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Models
{
    public class NOTIFICATION
    {
        public string proceedingReqId { get; set; }
        public string proceedingName { get; set; }
        public string pan { get; set; }
        public string nameOfAssesse { get; set; }
        public string assessmentYear { get; set; }
        public string financialYr { get; set; }
        public string noticeName { get; set; }
        public string proceedingStatus { get; set; }
        public string documentReferenceId { get; set; }
        public string description { get; set; }
        public long? issuedOn { get; set; }
        public long? responseDueDate { get; set; }
    }
}
