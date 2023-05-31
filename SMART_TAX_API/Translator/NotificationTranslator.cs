using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Translator
{
    public static class NotificationTranslator
    {
        public static NOTIFICATION TranslateAsNotification(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new NOTIFICATION();

            if (reader.IsColumnExists("proceedingReqId"))
                item.proceedingReqId = SqlHelper.GetNullableString(reader, "proceedingReqId");

            if (reader.IsColumnExists("proceedingName"))
                item.proceedingName = SqlHelper.GetNullableString(reader, "proceedingName");

            if (reader.IsColumnExists("pan"))
                item.pan = SqlHelper.GetNullableString(reader, "pan");

            if (reader.IsColumnExists("nameOfAssesse"))
                item.nameOfAssesse = SqlHelper.GetNullableString(reader, "nameOfAssesse");

            if (reader.IsColumnExists("assessmentYear"))
                item.assessmentYear = SqlHelper.GetNullableString(reader, "assessmentYear");

            if (reader.IsColumnExists("financialYr"))
                item.financialYr = SqlHelper.GetNullableString(reader, "financialYr");

            if (reader.IsColumnExists("noticeName"))
                item.noticeName = SqlHelper.GetNullableString(reader, "noticeName");

            if (reader.IsColumnExists("proceedingStatus"))
                item.proceedingStatus = SqlHelper.GetNullableString(reader, "proceedingStatus");

            if (reader.IsColumnExists("documentReferenceId"))
                item.documentReferenceId = SqlHelper.GetNullableString(reader, "documentReferenceId");

            if (reader.IsColumnExists("description"))
                item.description = SqlHelper.GetNullableString(reader, "description");

            if (reader.IsColumnExists("issuedOn"))
                item.issuedOn = SqlHelper.GetNullableLong(reader, "issuedOn");

            //if (reader.IsColumnExists("responseDueDate"))
            //    item.responseDueDate = SqlHelper.GetNullableLong(reader, "responseDueDate");


            return item;
        }
    }
}
