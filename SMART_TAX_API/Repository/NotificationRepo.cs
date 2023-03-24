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
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 250) { Value = "GET_NOTIFICATION_LIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_NOTIFICATION", parameters);
                List<NOTIFICATION> master = SqlHelper.CreateListFromTable<NOTIFICATION>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetNotificationCount(string connstring)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.NVarChar, 250) { Value = "GET_NOTIFICATION_COUNT" },

            };

                return SqlHelper.ExecuteProcedureReturnString(connstring, "SP_NOTIFICATION", parameters);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
