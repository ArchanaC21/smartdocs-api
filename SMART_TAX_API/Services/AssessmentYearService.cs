using Microsoft.Extensions.Configuration;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using SMART_TAX_API.Repository;
using SMART_TAX_API.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Services
{
    public class AssessmentYearService : IAssessmentYearService
    {
        private readonly IConfiguration _config;
        public AssessmentYearService(IConfiguration config)
        {
            _config = config;
        }

        public Response<List<ASSESSMENT_YEAR_MASTER>> GetAssYearByCompanyId(int CompanyId)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<ASSESSMENT_YEAR_MASTER>> response = new Response<List<ASSESSMENT_YEAR_MASTER>>();
            var data = DbClientFactory<AssessmentYearRepo>.Instance.GetAssYearByCompanyId(dbConn, CompanyId);

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

        public Response<string> InsertAssessmentYearForm(ASSESSMENT_YEAR_MASTER form)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            string SectionID = DbClientFactory<AssessmentYearRepo>.Instance.InsertForm(dbConn, form);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;
            response.Data = SectionID;

            return response;
        }

        public Response<ASSESSMENT_YEAR_MASTER> GetAssYearDetails(int CompanyId, string AssYear)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<ASSESSMENT_YEAR_MASTER> response = new Response<ASSESSMENT_YEAR_MASTER>();

            var data = DbClientFactory<AssessmentYearRepo>.Instance.GetAssYearDetails(dbConn, CompanyId, AssYear);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                ASSESSMENT_YEAR_MASTER detail = new ASSESSMENT_YEAR_MASTER();

                detail = AssessmentYearRepo.GetSingleDataFromDataSet<ASSESSMENT_YEAR_MASTER>(data.Tables[0]);

                if (data.Tables.Contains("Table1"))
                {
                    detail.NAME_OF_AUDITOR = AssessmentYearRepo.GetListFromDataSet<ASSESSMENT_YEAR_DETAILS>(data.Tables[1]);
                }
                if (data.Tables.Contains("Table2"))
                {
                    detail.CEO = AssessmentYearRepo.GetListFromDataSet<ASSESSMENT_YEAR_DETAILS>(data.Tables[2]);
                }
                if (data.Tables.Contains("Table3"))
                {
                    detail.CFO = AssessmentYearRepo.GetListFromDataSet<ASSESSMENT_YEAR_DETAILS>(data.Tables[3]);
                }
                if (data.Tables.Contains("Table4"))
                {
                    detail.MAIN_BANKER = AssessmentYearRepo.GetListFromDataSet<ASSESSMENT_YEAR_DETAILS>(data.Tables[4]);
                }
                if (data.Tables.Contains("Table5"))
                {
                    detail.DIRECTOR = AssessmentYearRepo.GetListFromDataSet<ASSESSMENT_YEAR_DETAILS>(data.Tables[5]);
                }

                response.Data = detail;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> UpdateAssessmentYearForm(ASSESSMENT_YEAR_MASTER form)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<AssessmentYearRepo>.Instance.UpdateForm(dbConn, form);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
