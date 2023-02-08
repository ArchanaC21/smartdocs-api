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
    public class FormRepo
    {
        public string InsertForm(string connstring, FORM request)
        {
            try
            {
                SqlParameter[] parameters =
                {
                  new SqlParameter("@OPERATION", SqlDbType.VarChar, 255) { Value = "INSERT_FORM" },
                  new SqlParameter("@FIRST_NAME", SqlDbType.VarChar, 50) { Value = request.FIRST_NAME },
                  new SqlParameter("@MIDDLE_NAME", SqlDbType.VarChar, 50) { Value = request.MIDDLE_NAME },
                  new SqlParameter("@LAST_NAME", SqlDbType.VarChar, 50) { Value = request.LAST_NAME },
                  new SqlParameter("@GENDER", SqlDbType.VarChar, 50) { Value = request.GENDER },
                  new SqlParameter("@DATE_OF_BIRTH", SqlDbType.Date) { Value = request.DATE_OF_BIRTH },
                  new SqlParameter("@DESIGNATION", SqlDbType.VarChar, 50) { Value = request.DESIGNATION },
                  new SqlParameter("@FLAT", SqlDbType.VarChar, 50)  { Value = request.FLAT },
                  new SqlParameter("@NAME_OF_PREMISES",SqlDbType.VarChar, 50) {Value = request.NAME_OF_PREMISES},
                  new SqlParameter("@ROAD", SqlDbType.VarChar, 50) { Value = request.ROAD },
                  new SqlParameter("@AREA", SqlDbType.VarChar, 50) { Value = request.AREA },
                  new SqlParameter("@TOWN", SqlDbType.VarChar, 50) { Value = request.TOWN },
                  new SqlParameter("@STATE", SqlDbType.VarChar, 50) { Value = request.STATE },
                  new SqlParameter("@PIN_CODE", SqlDbType.VarChar, 50) { Value = request.PIN_CODE },
                  new SqlParameter("@EMAIL_ADDRESS", SqlDbType.VarChar, 50) { Value = request.EMAIL_ADDRESS },
                  new SqlParameter("@PHONE_NO", SqlDbType.VarChar, 50) { Value = request.PHONE_NO },
                  new SqlParameter("@MOBILE_NO", SqlDbType.VarChar, 50) { Value = request.MOBILE_NO },
                  new SqlParameter("@RESIDENT_TYPE", SqlDbType.VarChar, 50) { Value = request.RESIDENT_TYPE },
                  new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = request.STATUS },

                  new SqlParameter("@NAME_OF_PARTY", SqlDbType.VarChar, 250) { Value = request.NAME_OF_PARTY },
                  new SqlParameter("@ADDRESS_OF_PARTY", SqlDbType.VarChar, 250) { Value = request.ADDRESS_OF_PARTY },
                  new SqlParameter("@PAN_OF_PARTY", SqlDbType.VarChar, 250) { Value = request.PAN_OF_PARTY },
                  new SqlParameter("@PARTICULARS_OF_ASSET", SqlDbType.VarChar, 250) { Value = request.PARTICULARS_OF_ASSET },
                  new SqlParameter("@EXPECTED_DATE_OF_TRANSFER", SqlDbType.Date) { Value = request.EXPECTED_DATE_OF_TRANSFER },
                  new SqlParameter("@PERIOD", SqlDbType.VarChar, 50) { Value = request.PERIOD },
                  new SqlParameter("@ADDITIONAL_INFO", SqlDbType.VarChar, 250) { Value = request.ADDITIONAL_INFO },
                  new SqlParameter("@NATURE_OF_TRANSACTION", SqlDbType.VarChar, 250) { Value = request.NATURE_OF_TRANSACTION },
                  new SqlParameter("@ASSESSEE_OUTSTANDING_DEMAND", SqlDbType.VarChar, 250) { Value = request.ASSESSEE_OUTSTANDING_DEMAND },
                  new SqlParameter("@IS_CIR_CIBIL_AVAILABLE", SqlDbType.VarChar, 50) { Value = request.IS_CIR_CIBIL_AVAILABLE },
                };

                var SectionID = SqlHelper.ExecuteProcedureReturnString(connstring, "SP_SECTION281_DTLS", parameters);

                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("SECTION_ID", typeof(int)));
                tbl.Columns.Add(new DataColumn("ASSESSMENT_YEAR", typeof(int)));
                tbl.Columns.Add(new DataColumn("DEMAND_SECTION", typeof(string)));
                tbl.Columns.Add(new DataColumn("OUTSTANDING_DEMAND", typeof(string)));
                tbl.Columns.Add(new DataColumn("PARTICULARS_OF_STAY", typeof(string)));
                tbl.Columns.Add(new DataColumn("REMARKS", typeof(string)));

                foreach (var i in request.PARTB_FORM)
                {
                    DataRow dr = tbl.NewRow();

                    dr["SECTION_ID"] = Convert.ToInt32(SectionID);
                    dr["ASSESSMENT_YEAR"] = i.ASSESSMENT_YEAR;
                    dr["DEMAND_SECTION"] = i.DEMAND_SECTION;
                    dr["OUTSTANDING_DEMAND"] = i.OUTSTANDING_DEMAND;
                    dr["PARTICULARS_OF_STAY"] = i.PARTICULARS_OF_STAY;
                    dr["REMARKS"] = i.REMARKS;

                    tbl.Rows.Add(dr);
                }

                string[] columns = new string[6];
                columns[0] = "SECTION_ID";
                columns[1] = "ASSESSMENT_YEAR";
                columns[2] = "DEMAND_SECTION";
                columns[3] = "OUTSTANDING_DEMAND";
                columns[4] = "PARTICULARS_OF_STAY";
                columns[5] = "REMARKS";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "SECTION281_PARTB_DTLS", columns);

                DataTable tbl1 = new DataTable();
                tbl1.Columns.Add(new DataColumn("SECTION_ID", typeof(int)));
                tbl1.Columns.Add(new DataColumn("ASSET_DESCRIPTION", typeof(string)));
                tbl1.Columns.Add(new DataColumn("PARTICULARS_OF_PLACE", typeof(string)));
                tbl1.Columns.Add(new DataColumn("VALUE_OF_THE_ASSET", typeof(string)));
                tbl1.Columns.Add(new DataColumn("IS_CHARGE_EXISTS", typeof(string)));
                tbl1.Columns.Add(new DataColumn("REMARKS", typeof(string)));

                foreach (var i in request.PARTC_FORM)
                {
                    DataRow dr = tbl1.NewRow();

                    dr["SECTION_ID"] = Convert.ToInt32(SectionID);
                    dr["ASSET_DESCRIPTION"] = i.ASSET_DESCRIPTION;
                    dr["PARTICULARS_OF_PLACE"] = i.PARTICULARS_OF_PLACE;
                    dr["VALUE_OF_THE_ASSET"] = i.VALUE_OF_THE_ASSET;
                    dr["IS_CHARGE_EXISTS"] = i.IS_CHARGE_EXISTS;
                    dr["REMARKS"] = i.REMARKS;

                    tbl1.Rows.Add(dr);
                }

                string[] columns1 = new string[6];
                columns1[0] = "SECTION_ID";
                columns1[1] = "ASSET_DESCRIPTION";
                columns1[2] = "PARTICULARS_OF_PLACE";
                columns1[3] = "VALUE_OF_THE_ASSET";
                columns1[4] = "IS_CHARGE_EXISTS";
                columns1[5] = "REMARKS";

                SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl1, "SECTION281_PARTC_DTLS", columns1);

                
                return SectionID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GetFormDetails(string connstring, int SectionId)
        {
            try
            {
                SqlParameter[] parameters =
            {
                new SqlParameter("@OPERATION", SqlDbType.VarChar, 50) { Value = "GET_FORM" },
                new SqlParameter("@SECTION_ID", SqlDbType.VarChar, 100) { Value = SectionId },
                
            };

                return SqlHelper.ExtecuteProcedureReturnDataSet(connstring, "SP_SECTION281_DTLS", parameters);
            }
            catch (Exception)
            {
                throw;
            }

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
