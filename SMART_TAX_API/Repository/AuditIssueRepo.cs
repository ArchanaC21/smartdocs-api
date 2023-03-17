using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using SMART_TAX_API.Translator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Repository
{
    public class AuditRepo
    {
        public void InsertAudit(string connstring, AUDIT_ISSUE request)
        {

            try
            {
                SqlParameter[] parameters =
                {
                 new SqlParameter("@OPERATION",SqlDbType.NVarChar,255) { Value = "INSERT_AUDIT_ISSUE" },
                 new SqlParameter("@COMPANY_ID",SqlDbType.Int) {Value=request.COMPANY_ID },
                 new SqlParameter("@ASSESSMENT_YEAR",SqlDbType.NVarChar,50) {Value=request.ASSESSMENT_YEAR },
                 new SqlParameter("@ISSUE",SqlDbType.NVarChar,255) {Value=request.ISSUE },
                 new SqlParameter("@RAISED_DATE",SqlDbType.Date){Value=request.RAISED_DATE },
                 new SqlParameter("@DUE_DATE",SqlDbType.Date){Value=request.DUE_DATE },
                 new SqlParameter("@STATUS",SqlDbType.NVarChar,250){Value=request.STATUS },
                 new SqlParameter("@SEVERITY",SqlDbType.NVarChar,250){Value=request.SEVERITY },
                 new SqlParameter("@RESOLUTION",SqlDbType.NVarChar,255){Value=request.RESOLUTION },
                 new SqlParameter("@CLOSURE_DATE",SqlDbType.Date){Value=request.CLOSURE_DATE}

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_AUDIT_ISSUE", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<AUDIT_ISSUE> GetAuditList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_AUDIT_ISSUE" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_AUDIT_ISSUE", parameters);
                List<AUDIT_ISSUE> auditList = SqlHelper.CreateListFromTable<AUDIT_ISSUE>(dataTable);

                return auditList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public AUDIT_ISSUE GetDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<AUDIT_ISSUE>(connstring, "SP_AUDIT_ISSUE", r => r.TranslateAsAuditIssue(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateAuditIssue(string connstring, AUDIT_ISSUE request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,255) { Value = "UPDATE_ACCOUNT_AUDIT_ISSUE" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = request.ID},
                  new SqlParameter("@ISSUE",SqlDbType.NVarChar,255) {Value=request.ISSUE },
                  new SqlParameter("@RAISED_DATE",SqlDbType.Date){Value=request.RAISED_DATE },
                  new SqlParameter("@DUE_DATE",SqlDbType.Date){Value=request.DUE_DATE },
                  new SqlParameter("@STATUS",SqlDbType.NVarChar,250){Value=request.STATUS },
                  new SqlParameter("@SEVERITY",SqlDbType.NVarChar,250){Value=request.SEVERITY },
                  new SqlParameter("@RESOLUTION",SqlDbType.NVarChar,255){Value=request.RESOLUTION },
                  new SqlParameter("@CLOSURE_DATE",SqlDbType.Date){Value=request.CLOSURE_DATE}

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_AUDIT_ISSUE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAuditIssue(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_ACCOUNT_AUDIT_ISSUE" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_AUDIT_ISSUE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
