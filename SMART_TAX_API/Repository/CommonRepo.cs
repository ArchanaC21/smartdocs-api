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
    public class CommonRepo
    {

        #region "SYSTEM TYPE MASTER"
        public void InsertSystemTypeMaster(string connstring, SYSTEM_TYPE_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,50) { Value = "INSERT_SYSTEM_TYPE" },
                  new SqlParameter("@P_CATEGORY", SqlDbType.NVarChar,50) { Value = master.CATEGORY},
                  new SqlParameter("@P_NAME", SqlDbType.NVarChar, 50) { Value = master.NAME },
                  new SqlParameter("@P_DESC", SqlDbType.NVarChar, 50) { Value = master.DESCRIPTION },
                  new SqlParameter("@P_STATUS", SqlDbType.Bit) { Value = master.STATUS },
                 
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_SYSTEM_TYPE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SYSTEM_TYPE_MASTER> GetSystemTypeMasterList(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_SYSTEM_TYPE" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MST_SYSTEM_TYPE", parameters);
                List<SYSTEM_TYPE_MASTER> master = SqlHelper.CreateListFromTable<SYSTEM_TYPE_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SYSTEM_TYPE_MASTER GetSystemTypeMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@P_ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_SYSTEM_TYPE_BY_ID" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<SYSTEM_TYPE_MASTER>(connstring, "SP_MST_SYSTEM_TYPE", r => r.TranslateAsSystemTypeMaster(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateSystemTypeMaster(string connstring, SYSTEM_TYPE_MASTER master)
        {
            try
            {
                SqlParameter[] parameters =
               {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,50) { Value = "UPDATE_SYSTEM_TYPE" },
                  new SqlParameter("@P_ID", SqlDbType.Int) { Value = master.ID},
                  new SqlParameter("@P_CATEGORY", SqlDbType.NVarChar, 50) { Value = master.CATEGORY},
                  new SqlParameter("@P_NAME", SqlDbType.NVarChar, 50) { Value = master.NAME },
                  new SqlParameter("@P_DESC", SqlDbType.NVarChar, 50) { Value = master.DESCRIPTION },
                  new SqlParameter("@P_STATUS", SqlDbType.NVarChar, 50) { Value = master.STATUS },
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_SYSTEM_TYPE", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteSystemTypeMaster(string connstring, int ID)
        {
            SqlParameter[] parameters =
            {
              new SqlParameter("@P_ID", SqlDbType.Int) { Value = ID },
               new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "DELETE_SYSTEM_TYPE" }
            };

            SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_SYSTEM_TYPE", parameters);
        }

        #endregion

        public List<SYSTEM_TYPE_MASTER> GetCategoryFromSystemType(string dbConn, string category)
        {
            try
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@P_CATEGORY", SqlDbType.NVarChar, 50) { Value = category },
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_CATEGORY_FROM_SYSTEM_TYPE" },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MST_SYSTEM_TYPE", parameters);
                List<SYSTEM_TYPE_MASTER> master = SqlHelper.CreateListFromTable<SYSTEM_TYPE_MASTER>(dataTable);

                return master;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
