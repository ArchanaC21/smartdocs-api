using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface IAssessmentYearService
    {
        Response<string> InsertAssessmentYearForm(ASSESSMENT_YEAR_MASTER form);
        Response<List<ASSESSMENT_YEAR_MASTER>> GetAssYearByCompanyId(int CompanyId);
        Response<ASSESSMENT_YEAR_MASTER> GetAssYearDetails(int CompanyId, string AssYear);
        Response<string> UpdateAssessmentYearForm(ASSESSMENT_YEAR_MASTER form);
    }
}
