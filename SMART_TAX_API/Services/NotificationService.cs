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
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _config;

        public NotificationService(IConfiguration config)
        {
            _config = config;
        }

        public Response<string> ChangeNotificationStatus(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<NotificationRepo>.Instance.ChangeNotificationstatus(dbConn, ID);

            Response<string> response = new Response<string>();

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.Message = "Updated Successfully";

            return response;
        }

        public Response<int> GetNotificationCount()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            int Total = Convert.ToInt32(DbClientFactory<NotificationRepo>.Instance.GetNotificationCount(dbConn));

            Response<int> response = new Response<int>();

            response.Succeeded = true;
            response.ResponseCode = 200;
            response.Data = Total;

            return response;
        }

        public Response<NOTIFICATION> GetNotificationDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<NOTIFICATION> response = new Response<NOTIFICATION>();
            var data = DbClientFactory<NotificationRepo>.Instance.GetNotificationDetails(dbConn, ID);

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

        public Response<List<NOTIFICATION>> notificationList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<NOTIFICATION>> response = new Response<List<NOTIFICATION>>();
            var data = DbClientFactory<NotificationRepo>.Instance.notificationList(dbConn);

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
