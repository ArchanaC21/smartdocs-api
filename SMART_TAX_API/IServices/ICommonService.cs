using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface ICommonService
    {
        #region "SYSTEM TYPE MASTER"
        Response<string> InsertSystemTypeMaster(SYSTEM_TYPE_MASTER request);

        Response<List<SYSTEM_TYPE_MASTER>> GetSystemTypeMasterList();

        Response<SYSTEM_TYPE_MASTER> GetSystemTypeMasterDetails(int ID);

        Response<string> UpdateSystemTypeMaster(SYSTEM_TYPE_MASTER request);

        Response<string> DeleteSystemTypeMaster(int ID);

        #endregion

        Response<List<SYSTEM_TYPE_MASTER>> GetCategoryFromSystemType(string Category);

    }
}
