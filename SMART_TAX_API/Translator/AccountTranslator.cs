using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Translator
{
    public static class AccountTranslator
    {
        public static USER TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new USER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableString(reader, "ID");

            if (reader.IsColumnExists("USERNAME"))
                item.USERNAME = SqlHelper.GetNullableString(reader, "USERNAME");

            if (reader.IsColumnExists("PASSWORD"))
                item.PASSWORD = SqlHelper.GetNullableString(reader, "PASSWORD");

            if (reader.IsColumnExists("EMPLOYEE_NAME"))
                item.EMPLOYEE_NAME = SqlHelper.GetNullableString(reader, "EMPLOYEE_NAME");

            if (reader.IsColumnExists("EMPLOYEE_CODE"))
                item.EMPLOYEE_CODE = SqlHelper.GetNullableString(reader, "EMPLOYEE_CODE");

            if (reader.IsColumnExists("DESIGNATION"))
                item.DESIGNATION = SqlHelper.GetNullableString(reader, "DESIGNATION");

            if (reader.IsColumnExists("EMAIL"))
                item.EMAIL = SqlHelper.GetNullableString(reader, "EMAIL");

            if (reader.IsColumnExists("ROLE"))
                item.ROLE = SqlHelper.GetNullableString(reader, "ROLE");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetBoolean(reader, "STATUS");

            
            return item;
        }

        public static USER_MASTER TranslateAsUserMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new USER_MASTER();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("PAN"))
                item.PAN = SqlHelper.GetNullableString(reader, "PAN");

            if (reader.IsColumnExists("PASSWORD"))
                item.PASSWORD = SqlHelper.GetNullableString(reader, "PASSWORD");

            if (reader.IsColumnExists("COMPANY_NAME"))
                item.COMPANY_NAME = SqlHelper.GetNullableString(reader, "COMPANY_NAME");

            if (reader.IsColumnExists("IS_ACTIVE"))
                item.IS_ACTIVE = SqlHelper.GetBoolean(reader, "IS_ACTIVE");

            return item;
        }
    }
}
