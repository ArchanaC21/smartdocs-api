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

        public NOTIFICATION GetNotificationDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@proceedingReqId", SqlDbType.NVarChar, 255) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_NOTIFICATION_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<NOTIFICATION>(connstring, "SP_NOTIFICATION", r => r.TranslateAsNotification(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void ChangeNotificationstatus(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@proceedingReqId", SqlDbType.NVarChar, 255) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "CHANGE_STATUS" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_NOTIFICATION", parameters);

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
