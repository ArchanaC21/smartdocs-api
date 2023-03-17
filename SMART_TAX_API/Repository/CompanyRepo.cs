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
    public class CompanyRepo
    {
        public void InsertCompanyMaster(string connstring, COMPANY request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,255) { Value = "INSERT_COMPANY" },
                  new SqlParameter("@CIN_NO", SqlDbType.NVarChar,50) { Value = request.CIN_NO},
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
                  new SqlParameter("@MOBILE_NO_1", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_1 },
                  new SqlParameter("@MOBILE_NO_2", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_2 },
                  new SqlParameter("@EMAIL_ID_1", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_1 },
                  new SqlParameter("@EMAIL_ID_2", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_2 },
                  new SqlParameter("@NATURE_OF_BUSINESS", SqlDbType.NVarChar,250) { Value = request.NATURE_OF_BUSINESS },
                  new SqlParameter("@INCOME_TAX_WARD", SqlDbType.NVarChar,100) { Value = request.INCOME_TAX_WARD },
                  new SqlParameter("@OTHER_CONTACT_PERSON", SqlDbType.NVarChar,100) { Value = request.OTHER_CONTACT_PERSON },
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

        public COMPANY GetCompanyMasterDetails(string connstring, int ID)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@ID", SqlDbType.Int) { Value = ID },
                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "GET_COMPANY_DETAILS" }
                };

                return SqlHelper.ExtecuteProcedureReturnData<COMPANY>(connstring, "SP_COMPANY", r => r.TranslateAsCompanyMaster(), parameters);
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
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar,255) { Value = "UPDATE_COMPANY" },
                  new SqlParameter("@ID", SqlDbType.Int) { Value = request.ID},
                  new SqlParameter("@CIN_NO", SqlDbType.NVarChar,50) { Value = request.CIN_NO},
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
                  new SqlParameter("@MOBILE_NO_1", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_1 },
                  new SqlParameter("@MOBILE_NO_2", SqlDbType.NVarChar, 50) { Value = request.MOBILE_NO_2 },
                  new SqlParameter("@EMAIL_ID_1", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_1 },
                  new SqlParameter("@EMAIL_ID_2", SqlDbType.NVarChar,100) { Value = request.EMAIL_ID_2 },
                  new SqlParameter("@NATURE_OF_BUSINESS", SqlDbType.NVarChar,250) { Value = request.NATURE_OF_BUSINESS },
                  new SqlParameter("@INCOME_TAX_WARD", SqlDbType.NVarChar,100) { Value = request.INCOME_TAX_WARD },
                  new SqlParameter("@OTHER_CONTACT_PERSON", SqlDbType.NVarChar,100) { Value = request.OTHER_CONTACT_PERSON },
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
                  new SqlParameter("@ID", SqlDbType.Int) { Value = Company_ID },
                   new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "DELETE_COMPANY" }
                };

                SqlHelper.ExecuteProcedureReturnString(connstring, "SP_COMPANY", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public VALIDATE_COMPANY ValidateComapny(string connstring, string CIN_NO, string PAN_NO)
        {
            try
            {
                SqlParameter[] parameters =
                {

                   new SqlParameter("@OPERATION", SqlDbType.NVarChar, 50) { Value = "VALIDATE_COMPANY" },
                   new SqlParameter("@CIN_NO", SqlDbType.NVarChar, 50) { Value = CIN_NO },
                   new SqlParameter("@PAN", SqlDbType.NVarChar, 100) { Value = PAN_NO },
                };

                return SqlHelper.ExtecuteProcedureReturnData<VALIDATE_COMPANY>(connstring, "SP_COMPANY", r => r.TranslateAsValidateCompany(), parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
