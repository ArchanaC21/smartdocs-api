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
    public class CompanyRepo
    {
        public void InsertCompanyMaster(string connstring, COMPANY request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,255) { Value = "INSERT_COMPANY" },
                  new SqlParameter("@NAME", SqlDbType.NVarChar,250) { Value = request.NAME},
                  new SqlParameter("@FORMER_NAME", SqlDbType.NVarChar, 250) { Value = request.FORMER_NAME },
                  new SqlParameter("@SHORT_NAME", SqlDbType.NVarChar, 100) { Value = request.SHORT_NAME },
                  new SqlParameter("@PAN", SqlDbType.NVarChar, 100) { Value = request.PAN },
                  new SqlParameter("@DATE_OF_INCORPORATION", SqlDbType.DateTime) { Value = request.DATE_OF_INCORPORATION },
                  new SqlParameter("@STATUS", SqlDbType.NVarChar, 50) { Value = request.STATUS },
                  new SqlParameter("@ADDRESS", SqlDbType.NVarChar,250) { Value = request.ADDRESS },
                  new SqlParameter("@CITY", SqlDbType.NVarChar,50) { Value = request.CITY },
                  new SqlParameter("@STATE", SqlDbType.NVarChar,50) { Value = request.STATE },
                  new SqlParameter("@PIN", SqlDbType.NVarChar,50) { Value = request.PIN },
                  new SqlParameter("@LANDLINE_NO_1", SqlDbType.NVarChar, 50) { Value = request.LANDLINE_NO_1 },
                  new SqlParameter("@LANDLINE_NO_2", SqlDbType.NVarChar, 50) { Value = request.LANDLINE_NO_2 },
                  new SqlParameter("@MOBILE_NO_1", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_1 },
                  new SqlParameter("@MOBILE_NO_2", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_2 },
                  new SqlParameter("@EMAIL_ID_1", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_1 },
                  new SqlParameter("@EMAIL_ID_2", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_2 },
                  new SqlParameter("@NATURE_OF_BUSINESS", SqlDbType.NVarChar,250) { Value = request.NATURE_OF_BUSINESS },
                  new SqlParameter("@INCOME_TAX_WARD", SqlDbType.NVarChar,100) { Value = request.INCOME_TAX_WARD },
                  new SqlParameter("@NAME_OF_STATUTORY_AUDITOR", SqlDbType.NVarChar,100) { Value = request.NAME_OF_STATUTORY_AUDITOR },
                  new SqlParameter("@CEO", SqlDbType.NVarChar,100) { Value = request.CEO },
                  new SqlParameter("@CFO", SqlDbType.NVarChar,100) { Value = request.CFO },
                  new SqlParameter("@OTHER_CONTACT_PERSON", SqlDbType.NVarChar,100) { Value = request.OTHER_CONTACT_PERSON },
                  new SqlParameter("@MAIN_BANKER", SqlDbType.NVarChar,100) { Value = request.MAIN_BANKER },
                  new SqlParameter("@VERTICALS", SqlDbType.NVarChar,100) { Value = request.VERTICALS },
                  
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_COMPANY", parameters);
            }
            catch (Exception)
            {

                throw;
            }

        }



        public List<COMPANY> GetCompany(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_COMPANY" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_COMPANY", parameters);
                List<COMPANY> companyList = SqlHelper.CreateListFromTable<COMPANY>(dataTable);

                return companyList;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateCompany(string connstring, COMPANY request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,255) { Value = "INSERT_COMPANY" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = request.ID},
                  new SqlParameter("@NAME", SqlDbType.NVarChar,250) { Value = request.NAME},
                  new SqlParameter("@FORMER_NAME", SqlDbType.NVarChar, 250) { Value = request.FORMER_NAME },
                  new SqlParameter("@SHORT_NAME", SqlDbType.NVarChar, 100) { Value = request.SHORT_NAME },
                  new SqlParameter("@PAN", SqlDbType.NVarChar, 100) { Value = request.PAN },
                  new SqlParameter("@DATE_OF_INCORPORATION", SqlDbType.DateTime) { Value = request.DATE_OF_INCORPORATION },
                  new SqlParameter("@STATUS", SqlDbType.NVarChar, 50) { Value = request.STATUS },
                  new SqlParameter("@ADDRESS", SqlDbType.NVarChar,250) { Value = request.ADDRESS },
                  new SqlParameter("@CITY", SqlDbType.NVarChar,50) { Value = request.CITY },
                  new SqlParameter("@STATE", SqlDbType.NVarChar,50) { Value = request.STATE },
                  new SqlParameter("@PIN", SqlDbType.NVarChar,50) { Value = request.PIN },
                  new SqlParameter("@LANDLINE_NO_1", SqlDbType.Int) { Value = request.LANDLINE_NO_1 },
                  new SqlParameter("@LANDLINE_NO_2", SqlDbType.Int) { Value = request.LANDLINE_NO_2 },
                  new SqlParameter("@MOBILE_NO_1", SqlDbType.Int) { Value = request.MOBILE_NO_1 },
                  new SqlParameter("@MOBILE_NO_2", SqlDbType.Int) { Value = request.MOBILE_NO_2 },
                  new SqlParameter("@EMAIL_ID_1", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_1 },
                  new SqlParameter("@EMAIL_ID_2", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_2 },
                  new SqlParameter("@NATURE_OF_BUSINESS", SqlDbType.NVarChar,250) { Value = request.NATURE_OF_BUSINESS },
                  new SqlParameter("@INCOME_TAX_WARD", SqlDbType.NVarChar,100) { Value = request.INCOME_TAX_WARD },
                  new SqlParameter("@NAME_OF_STATUTORY_AUDITOR", SqlDbType.NVarChar,100) { Value = request.NAME_OF_STATUTORY_AUDITOR },
                  new SqlParameter("@CEO", SqlDbType.NVarChar,100) { Value = request.CEO },
                  new SqlParameter("@CFO", SqlDbType.NVarChar,100) { Value = request.CFO },
                  new SqlParameter("@OTHER_CONTACT_PERSON", SqlDbType.NVarChar,100) { Value = request.OTHER_CONTACT_PERSON },
                  new SqlParameter("@MAIN_BANKER", SqlDbType.NVarChar,100) { Value = request.MAIN_BANKER },
                  new SqlParameter("@VERTICALS", SqlDbType.NVarChar,100) { Value = request.VERTICALS },

                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_COMPANY", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCompany(string connstring, int Company_ID)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@Company_ID", SqlDbType.Int) { Value = Company_ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_COMPANY" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_COMPANY", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<COMPANY_VERTICALS> GetCompanyVerticals(string dbConn)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_VERTICALS_LIST" },

                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_COMPANY", parameters);
                List<COMPANY_VERTICALS> companyVerticalsList = SqlHelper.CreateListFromTable<COMPANY_VERTICALS>(dataTable);

                return companyVerticalsList;
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
