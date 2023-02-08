using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using SMART_TAX_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface ICompanyService
    {
        Response<string> InsertCompanyMaster(COMPANY request);
        Response<List<COMPANY>> GetCompany();
        Response<CommonResponse> UpdateCompany(COMPANY request);
        Response<CommonResponse> DeleteCompany(int Company_ID);
        Response<List<COMPANY_VERTICALS>> GetCompanyVerticals();
    }
}
