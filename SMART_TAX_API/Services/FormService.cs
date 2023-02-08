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
    public class FormService : IFormService
    {
        private readonly IConfiguration _config;
        public FormService(IConfiguration config)
        {
            _config = config;
        }

        public Response<FORM> GetFormDetails(int SectionID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<FORM> response = new Response<FORM>();

            if (SectionID == 0) 
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide SectionID";
                return response;
            }

            var data = DbClientFactory<FormRepo>.Instance.GetFormDetails(dbConn, SectionID);

            if ((data != null) && (data.Tables[0].Rows.Count > 0))
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                FORM form = new FORM();

                form = FormRepo.GetSingleDataFromDataSet<FORM>(data.Tables[0]);

                if (data.Tables.Contains("Table1"))
                {
                    form.PARTB_FORM = FormRepo.GetListFromDataSet<PARTB_FORM>(data.Tables[1]);
                }

                if (data.Tables.Contains("Table2"))
                {
                    form.PARTC_FORM = FormRepo.GetListFromDataSet<PARTC_FORM>(data.Tables[2]);
                }

                response.Data = form;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> InsetForm(FORM form)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            string SectionID = DbClientFactory<FormRepo>.Instance.InsertForm(dbConn, form);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;
            response.Data = SectionID;

            return response;
        }
    }
}
