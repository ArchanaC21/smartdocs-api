using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Translator
{
    public static class SystemTypeMasterTranslator
    {
        public static SYSTEM_TYPE_MASTER TranslateAsSystemTypeMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new SYSTEM_TYPE_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CATEGORY"))
                item.CATEGORY = SqlHelper.GetNullableString(reader, "CATEGORY");

            if (reader.IsColumnExists("NAME"))
                item.NAME = SqlHelper.GetNullableString(reader, "NAME");

            if (reader.IsColumnExists("DESCRIPTION"))
                item.DESCRIPTION = SqlHelper.GetNullableString(reader, "DESCRIPTION");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");


            return item;
        }

    }
}
