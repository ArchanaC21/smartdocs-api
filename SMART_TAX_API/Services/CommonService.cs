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
    public class CommonService: ICommonService
    {
        private readonly IConfiguration _config;

        public CommonService(IConfiguration config)
        {
            _config = config;
        }

        #region "SYSTEM TYPE MASTER"
        public Response<string> DeleteSystemTypeMaster(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();

            if (ID == 0)
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<CommonRepo>.Instance.DeleteSystemTypeMaster(dbConn, ID);

            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<SYSTEM_TYPE_MASTER> GetSystemTypeMasterDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<SYSTEM_TYPE_MASTER> response = new Response<SYSTEM_TYPE_MASTER>();
            var data = DbClientFactory<CommonRepo>.Instance.GetSystemTypeMasterDetails(dbConn, ID);

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

        public Response<List<SYSTEM_TYPE_MASTER>> GetSystemTypeMasterList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SYSTEM_TYPE_MASTER>> response = new Response<List<SYSTEM_TYPE_MASTER>>();
            var data = DbClientFactory<CommonRepo>.Instance.GetSystemTypeMasterList(dbConn);

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

        public Response<string> InsertSystemTypeMaster(SYSTEM_TYPE_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<CommonRepo>.Instance.InsertSystemTypeMaster(dbConn, request);


            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> UpdateSystemTypeMaster(SYSTEM_TYPE_MASTER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();
            DbClientFactory<CommonRepo>.Instance.UpdateSystemTypeMaster(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        #endregion

        public Response<List<SYSTEM_TYPE_MASTER>> GetCategoryFromSystemType(string Category)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<SYSTEM_TYPE_MASTER>> response = new Response<List<SYSTEM_TYPE_MASTER>>();
            var data = DbClientFactory<CommonRepo>.Instance.GetCategoryFromSystemType(dbConn, Category);

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
