using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Repository
{
    public class BalanceSheetRepo
    {
        public void InsertBalanceSheetData(BALANCE_SHEET request, string connstring)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("ASSET", typeof(string)));
            tbl.Columns.Add(new DataColumn("ASSET_AMOUNT", typeof(decimal)));
            tbl.Columns.Add(new DataColumn("LIABILITY", typeof(string)));
            tbl.Columns.Add(new DataColumn("LIABILITY_AMOUNT", typeof(decimal)));

            foreach (var i in request.ASSETs)
            {
                DataRow dr = tbl.NewRow();

                dr["ASSET"] = i.ASSET;
                dr["ASSET_AMOUNT"] = i.ASSET_AMOUNT;

                tbl.Rows.Add(dr);
            }

            foreach (var i in request.LIABILITYs)
            {
                DataRow dr = tbl.NewRow();

                dr["LIABILITY"] = i.LIABILITY;
                dr["LIABILITY_AMOUNT"] = i.LIABILITY_AMOUNT;

                tbl.Rows.Add(dr);
            }

            string[] columns = new string[4];
            columns[0] = "ASSET";
            columns[1] = "ASSET_AMOUNT";
            columns[2] = "LIABILITY";
            columns[3] = "LIABILITY_AMOUNT";

            SqlHelper.ExecuteProcedureBulkInsert(connstring, tbl, "BALANCE_SHEET", columns);
        }
    }
}
