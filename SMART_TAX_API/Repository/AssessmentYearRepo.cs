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
    public class AssessmentYearRepo
    {
        public string InsertForm(string connstring, ASSESSMENT_YEAR_MASTER request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar, 255) { Value = "INSERT_ASSESSMENT_YEAR" },
                  new SqlParameter("@COMPANY_ID", SqlDbType.Int, 50) { Value = request.COMPANY_ID },
                  new SqlParameter("@ASSESSMENT_YEAR", SqlDbType.NVarChar, 50) { Value = request.ASSESSMENT_YEAR },
                  new SqlParameter("@IS_TAX_AUDIT", SqlDbType.Bit) { Value = request.IS_TAX_AUDIT },
                  new SqlParameter("@IS_TRANSFER_PRICING", SqlDbType.Bit) { Value = request.IS_TRANSFER_PRICING },
                  new SqlParameter("@IS_MASTER_FILING", SqlDbType.Bit) { Value = request.IS_MASTER_FILING },
                  new SqlParameter("@TA_DUE_DATE", SqlDbType.Date) { Value = request.TA_DUE_DATE },
                  new SqlParameter("@TP_DUE_DATE", SqlDbType.Date)  { Value = request.TP_DUE_DATE },
                  new SqlParameter("@MF_DUE_DATE",SqlDbType.Date) {Value = request.MF_DUE_DATE},

                };

                var result = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_ASSESSMENT_YEAR", parameters);

                if (result != "EXISTS")
                {
                    AssessmentYearBulkInsert(request, Convert.ToInt32(result), connstring);
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UpdateForm(string connstring, ASSESSMENT_YEAR_MASTER request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.NVarChar, 255) { Value = "UPDATE_ASSESSMENT_YEAR" },
                  new SqlParameter("@COMPANY_ID", SqlDbType.Int, 50) { Value = request.COMPANY_ID },
                  new SqlParameter("@ASSESSMENT_YEAR", SqlDbType.NVarChar, 50) { Value = request.ASSESSMENT_YEAR },
                  new SqlParameter("@IS_TAX_AUDIT", SqlDbType.Bit) { Value = request.IS_TAX_AUDIT },
                  new SqlParameter("@IS_TRANSFER_PRICING", SqlDbType.Bit) { Value = request.IS_TRANSFER_PRICING },
                  new SqlParameter("@IS_MASTER_FILING", SqlDbType.Bit) { Value = request.IS_MASTER_FILING },
                  new SqlParameter("@TA_DUE_DATE", SqlDbType.Date) { Value = request.TA_DUE_DATE },
                  new SqlParameter("@TP_DUE_DATE", SqlDbType.Date)  { Value = request.TP_DUE_DATE },
                  new SqlParameter("@MF_DUE_DATE",SqlDbType.Date) {Value = request.MF_DUE_DATE},

                };

                var AssessmentYearID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_MST_ASSESSMENT_YEAR", parameters);

                AssessmentYearBulkInsert(request, Convert.ToInt32(AssessmentYearID), connstring);

                return AssessmentYearID;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void AssessmentYearBulkInsert(ASSESSMENT_YEAR_MASTER request, int AssessmentYearID, string connstring)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("ASSESSMENT_YEAR_ID", typeof(int)));
            tbl.Columns.Add(new DataColumn("CATEGORY", typeof(string)));
            tbl.Columns.Add(new DataColumn("NAME", typeof(string)));
            tbl.Columns.Add(new DataColumn("FROM_DATE", typeof(DateTime)));
            tbl.Columns.Add(new DataColumn("TO_DATE", typeof(DateTime)));
            tbl.Columns.Add(new DataColumn("ACTIVE", typeof(bool)));

            foreach (var i in request.NAME_OF_AUDITOR)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSESSMENT_YEAR_ID"] = Convert.ToInt32(AssessmentYearID);
                dr["CATEGORY"] = i.CATEGORY;
                dr["NAME"] = i.NAME;
                dr["FROM_DATE"] = i.FROM_DATE;
                dr["TO_DATE"] = i.TO_DATE;
                dr["ACTIVE"] = true;

                tbl.Rows.Add(dr);
            }
            foreach (var i in request.CEO)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSESSMENT_YEAR_ID"] = Convert.ToInt32(AssessmentYearID);
                dr["CATEGORY"] = i.CATEGORY;
                dr["NAME"] = i.NAME;
                dr["FROM_DATE"] = i.FROM_DATE;
                dr["TO_DATE"] = i.TO_DATE;
                dr["ACTIVE"] = true;

                tbl.Rows.Add(dr);
            }
            foreach (var i in request.CFO)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSESSMENT_YEAR_ID"] = Convert.ToInt32(AssessmentYearID);
                dr["CATEGORY"] = i.CATEGORY;
                dr["NAME"] = i.NAME;
                dr["FROM_DATE"] = i.FROM_DATE;
                dr["TO_DATE"] = i.TO_DATE;
                dr["ACTIVE"] = true;

                tbl.Rows.Add(dr);
            }
            foreach (var i in request.MAIN_BANKER)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSESSMENT_YEAR_ID"] = Convert.ToInt32(AssessmentYearID);
                dr["CATEGORY"] = i.CATEGORY;
                dr["NAME"] = i.NAME;
                dr["FROM_DATE"] = i.FROM_DATE;
                dr["TO_DATE"] = i.TO_DATE;
                dr["ACTIVE"] = true;

                tbl.Rows.Add(dr);
            }
            foreach (var i in request.DIRECTOR)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSESSMENT_YEAR_ID"] = Convert.ToInt32(AssessmentYearID);
                dr["CATEGORY"] = i.CATEGORY;
                dr["NAME"] = i.NAME;
                dr["FROM_DATE"] = i.FROM_DATE;
                dr["TO_DATE"] = i.TO_DATE;
                dr["ACTIVE"] = true;

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[6];
            columns[0] = "ASSESSMENT_YEAR_ID";
            columns[1] = "CATEGORY";
            columns[2] = "NAME";
            columns[3] = "FROM_DATE";
            columns[4] = "TO_DATE";
            columns[5] = "ACTIVE";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "ASSESSMENT_YEAR_DETAILS", columns);
        }

        public List<ASSESSMENT_YEAR_MASTER> GetAssYearByCompanyId(string dbConn, int CompanyId)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "GET_ASS_YEAR_BY_COMPANY" },
                  new SqlParameter("@COMPANY_ID", SqlDbType.Int) { Value = CompanyId },
                };

                DataTable dataTable = SqlHelper.ExtecuteProcedureReturnDataTable(dbConn, "SP_MST_ASSESSMENT_YEAR", parameters);
                List<ASSESSMENT_YEAR_MASTER> List = SqlHelper.CreateListFromTable<ASSESSMENT_YEAR_MASTER>(dataTable);

                return List;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public DataSet GetAssYearDetails(string connstring, int companyId, string ass_year)
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_ASS_YEAR_DETAILS" },
                new SqlParameter("@COMPANY_ID", SqlDbType.VarChar, 100) { Value = companyId },
                new SqlParameter("@ASSESSMENT_YEAR", SqlDbType.VarChar, 100) { Value = ass_year },

            };

            return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_MST_ASSESSMENT_YEAR", parameters);
        }

        public static T GetSingleDataFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateItemFromRow<T>(dataTable.Rows[0]);
        }

        public static List<T> GetListFromDataSet<T>(DataTable dataTable) where T : new()
        {
            return SqlHelper.CreateListFromTable<T>(dataTable);
        }
    }
}
