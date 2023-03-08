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
    public class BalanceSheetService : IBalanceSheetService
    {
        private readonly IConfiguration _config;
        public BalanceSheetService(IConfiguration config)
        {
            _config = config;
        }

        public Response<string> InsertBalanceSheetForm(BALANCE_SHEET form)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<BalanceSheetRepo>.Instance.InsertBalanceSheetData(form, dbConn);

            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Inserted Successfully.";
            response.ResponseCode = 200;

            return response;
        }
    }
}
