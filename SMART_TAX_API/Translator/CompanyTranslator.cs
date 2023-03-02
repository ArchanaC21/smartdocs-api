using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Translator
{
    public static class CompanyTranslator
    {
        public static COMPANY TranslateAsCompanyMaster(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new COMPANY();

            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNullableInt32(reader, "ID");

            if (reader.IsColumnExists("CIN_NO"))
                item.CIN_NO = SqlHelper.GetNullableString(reader, "CIN_NO");

            if (reader.IsColumnExists("NAME"))
                item.NAME = SqlHelper.GetNullableString(reader, "NAME");

            if (reader.IsColumnExists("FORMER_NAME"))
                item.FORMER_NAME = SqlHelper.GetNullableString(reader, "FORMER_NAME");

            if (reader.IsColumnExists("SHORT_NAME"))
                item.SHORT_NAME = SqlHelper.GetNullableString(reader, "SHORT_NAME");

            if (reader.IsColumnExists("PAN"))
                item.PAN = SqlHelper.GetNullableString(reader, "PAN");

            if (reader.IsColumnExists("DATE_OF_INCORPORATION"))
                item.DATE_OF_INCORPORATION = SqlHelper.GetDateTime(reader, "DATE_OF_INCORPORATION");

            if (reader.IsColumnExists("STATUS"))
                item.STATUS = SqlHelper.GetNullableString(reader, "STATUS");

            if (reader.IsColumnExists("ADDRESS"))
                item.ADDRESS = SqlHelper.GetNullableString(reader, "ADDRESS");

            if (reader.IsColumnExists("CITY"))
                item.CITY = SqlHelper.GetNullableString(reader, "CITY");

            if (reader.IsColumnExists("STATE"))
                item.STATE = SqlHelper.GetNullableString(reader, "STATE");

            if (reader.IsColumnExists("PIN"))
                item.PIN = SqlHelper.GetNullableString(reader, "PIN");

            if (reader.IsColumnExists("MOBILE_NO_1"))
                item.MOBILE_NO_1 = SqlHelper.GetNullableString(reader, "MOBILE_NO_1");

            if (reader.IsColumnExists("MOBILE_NO_2"))
                item.MOBILE_NO_2 = SqlHelper.GetNullableString(reader, "MOBILE_NO_2");

            if (reader.IsColumnExists("EMAIL_ID_1"))
                item.EMAIL_ID_1 = SqlHelper.GetNullableString(reader, "EMAIL_ID_1");

            if (reader.IsColumnExists("EMAIL_ID_2"))
                item.EMAIL_ID_2 = SqlHelper.GetNullableString(reader, "EMAIL_ID_2");

            if (reader.IsColumnExists("NATURE_OF_BUSINESS"))
                item.NATURE_OF_BUSINESS = SqlHelper.GetNullableString(reader, "NATURE_OF_BUSINESS");

            if (reader.IsColumnExists("INCOME_TAX_WARD"))
                item.INCOME_TAX_WARD = SqlHelper.GetNullableString(reader, "INCOME_TAX_WARD");

            if (reader.IsColumnExists("OTHER_CONTACT_PERSON"))
                item.OTHER_CONTACT_PERSON = SqlHelper.GetNullableString(reader, "OTHER_CONTACT_PERSON");

            if (reader.IsColumnExists("VERTICALS"))
                item.VERTICALS = SqlHelper.GetNullableString(reader, "VERTICALS");

            return item;
        }

        public static VALIDATE_COMPANY TranslateAsValidateCompany(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new VALIDATE_COMPANY();

            if (reader.IsColumnExists("CIN_NO"))
                item.CIN_NO = SqlHelper.GetNullableString(reader, "CIN_NO");

            if (reader.IsColumnExists("PAN"))
                item.PAN = SqlHelper.GetNullableString(reader, "PAN");
            
            return item;
        }
    }
}
