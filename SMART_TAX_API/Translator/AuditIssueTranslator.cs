using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Translator
{
    public static class AuditIssueTranslator
    {
        public static AUDIT_ISSUE TranslateAsAuditIssue(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new AUDIT_ISSUE();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("ISSUE"))
                item.ISSUE = SqlHelper.GetNullableString(reader, "ISSUE");

            if (reader.IsColumnExists("RAISED_DATE"))
                item.RAISED_DATE = SqlHelper.GetDateTime(reader, "RAISED_DATE");

            if (reader.IsColumnExists("DUE_DATE"))
                item.DUE_DATE = SqlHelper.GetDateTime(reader, "DUE_DATE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableString(reader, "STATUS");

            if (reader.IsColumnExists("SEVERITY"))
                item.SEVERITY = SqlHelper.GetNullableString(reader, "SEVERITY");

            if (reader.IsColumnExists("RESOLUTION"))
                item.RESOLUTION = SqlHelper.GetNullableString(reader, "RESOLUTION");

            if (reader.IsColumnExists("CLOSURE_DATE"))
                item.CLOSURE_DATE = SqlHelper.GetDateTime(reader, "CLOSURE_DATE");

            return item;
        }

    }
}
