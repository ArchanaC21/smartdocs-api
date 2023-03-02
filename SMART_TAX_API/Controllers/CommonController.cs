using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        #region "SYSTEM TYPE MASTER"

        [HttpPost("InsertSystemTypeMaster")]
        public ActionResult<Response<string>> InsertSystemTypeMaster(SYSTEM_TYPE_MASTER request)
        {
            return Ok(_commonService.InsertSystemTypeMaster(request));
        }

        [HttpGet("GetSystemTypeMasterList")]
        public ActionResult<Response<List<SYSTEM_TYPE_MASTER>>> GetSystemTypeMasterList()
        {
            return Ok(JsonConvert.SerializeObject(_commonService.GetSystemTypeMasterList()));
        }

        [HttpGet("GetSystemTypeMasterDetails")]
        public ActionResult<Response<SYSTEM_TYPE_MASTER>> GetSystemTypeMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_commonService.GetSystemTypeMasterDetails(ID)));
        }

        [HttpPost("UpdateSystemTypeMaster")]
        public ActionResult<Response<string>> UpdateSystemTypeMaster(SYSTEM_TYPE_MASTER request)
        {
            return Ok(_commonService.UpdateSystemTypeMaster(request));
        }

        [HttpDelete("DeleteSystemTypeMaster")]
        public ActionResult<Response<string>> DeleteSystemTypeMaster(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_commonService.DeleteSystemTypeMaster(ID)));
        }

        #endregion

        [HttpGet("GetCategoryFromSystemType")]
        public ActionResult<Response<List<SYSTEM_TYPE_MASTER>>> GetCategoryFromSystemType(string CATEGORY)
        {
            return Ok(JsonConvert.SerializeObject(_commonService.GetCategoryFromSystemType(CATEGORY)));
        }

    }
}
