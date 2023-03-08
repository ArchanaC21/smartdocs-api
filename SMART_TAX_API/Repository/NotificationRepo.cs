using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Repository
{
    public class NotificationRepo
    {
        public List<NOTIFICATION> notificationList(string dbConn)
        {
            try
            {
                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_NOTIFICATION");
                List<NOTIFICATION> master = SqlHelper.CreateListFromTable<NOTIFICATION>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
