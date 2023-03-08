using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SMART_TAX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private ICommonService _commonService;
        private readonly IWebHostEnvironment _environment;
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

        [HttpPost("UploadFiles"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "BalanceSheets");
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
