using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using SMART_TAX_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("InsertCompanyMaster")]
        public ActionResult<Response<string>> InsertCompanyMaster(COMPANY request)
        {
            return Ok(_companyService.InsertCompanyMaster(request));
        }

        [Authorize]
        [HttpGet("GetCompany")]
        public ActionResult<Response<List<COMPANY>>> GetCompany()
        {
            return Ok(JsonConvert.SerializeObject(_companyService.GetCompany()));
        }

        [HttpGet("GetCompanyMasterDetails")]
        public ActionResult<Response<COMPANY>> GetCompanyMasterDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_companyService.GetCompanyMasterDetails(ID)));
        }

        [HttpPut("UpdateCompany")]
        public ActionResult<Response<string>> UpdateCompany(COMPANY request)
        {
            return Ok(_companyService.UpdateCompany(request));
        }

        [HttpDelete("DeleteCompany")]
        public ActionResult<Response<string>> DeleteCompany(int Company_ID)
        {
            return Ok(JsonConvert.SerializeObject(_companyService.DeleteCompany(Company_ID)));
        }

        [HttpGet("ValidateCompany")]
        public ActionResult<Response<VALIDATE_COMPANY>> ValidateCompany(string CIN_NO, string PAN_NO)
        {
            return Ok(JsonConvert.SerializeObject(_companyService.ValidateCompany(CIN_NO,PAN_NO)));
        }

    }
}
