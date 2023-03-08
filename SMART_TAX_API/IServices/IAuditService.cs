using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using SMART_TAX_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface IAuditService
    {
        Response<string> InsertAudit(AUDIT_ISSUE request);

        Response<List<AUDIT_ISSUE>> GetAuditList();

        Response<AUDIT_ISSUE> GetDetails(int ID);

        Response<string> UpdateAuditIssue(AUDIT_ISSUE request);
        Response<string> DeleteAuditIssue(int ID);







    }
}
