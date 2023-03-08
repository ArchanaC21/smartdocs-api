using Microsoft.Extensions.Configuration;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using SMART_TAX_API.Repository;
using SMART_TAX_API.Response;
using SMART_TAX_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Services
{
    public class AuditIssueService : IAuditService
    {
        private readonly IConfiguration _config;

        public AuditIssueService(IConfiguration config)
        {
            _config = config;
        }

        public Response<string> InsertAudit(AUDIT_ISSUE request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<AuditRepo>.Instance.InsertAudit(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Account Audit Issue Saved Successfully";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<AUDIT_ISSUE>> GetAuditList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<AUDIT_ISSUE>> response = new Response<List<AUDIT_ISSUE>>();
            var data = DbClientFactory<AuditRepo>.Instance.GetAuditList(dbConn);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<AUDIT_ISSUE> GetDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<AUDIT_ISSUE> response = new Response<AUDIT_ISSUE>();
            var data = DbClientFactory<AuditRepo>.Instance.GetDetails(dbConn, ID);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> UpdateAuditIssue(AUDIT_ISSUE request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();
            DbClientFactory<AuditRepo>.Instance.UpdateAuditIssue(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = " updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> DeleteAuditIssue(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();

            if ((ID == 0) || (ID == 0))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<AuditRepo>.Instance.DeleteAuditIssue(dbConn, ID);

            response.Succeeded = true;
            response.ResponseMessage = "deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }



    }
}
