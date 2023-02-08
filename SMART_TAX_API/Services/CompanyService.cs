﻿using Microsoft.Extensions.Configuration;
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
    public class CompanyService : ICompanyService
    {
        private readonly IConfiguration _config;

        public CompanyService(IConfiguration config)
        {
            _config = config;
        }

        public Response<string> InsertCompanyMaster(COMPANY request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<CompanyRepo>.Instance.InsertCompanyMaster(dbConn, request);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<COMPANY>> GetCompany()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<COMPANY>> response = new Response<List<COMPANY>>();
            var data = DbClientFactory<CompanyRepo>.Instance.GetCompany(dbConn);

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

        public Response<CommonResponse> UpdateCompany(COMPANY request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();
            DbClientFactory<CompanyRepo>.Instance.UpdateCompany(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<CommonResponse> DeleteCompany(int Company_ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<CommonResponse> response = new Response<CommonResponse>();

            if ((Company_ID == 0) || (Company_ID == 0))
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<CompanyRepo>.Instance.DeleteCompany(dbConn, Company_ID);

            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<List<COMPANY_VERTICALS>> GetCompanyVerticals()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<COMPANY_VERTICALS>> response = new Response<List<COMPANY_VERTICALS>>();
            var data = DbClientFactory<CompanyRepo>.Instance.GetCompanyVerticals(dbConn);

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
    }
}