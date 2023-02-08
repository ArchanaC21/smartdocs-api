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
        public ActionResult<Response<CommonResponse>> InsertCompanyMaster(COMPANY request)
        {
            return Ok(_companyService.InsertCompanyMaster(request));
        }

        [HttpGet("GetCompany")]
        public ActionResult<Response<List<COMPANY>>> GetCompany()
        {
            return Ok(JsonConvert.SerializeObject(_companyService.GetCompany()));
        }

        [HttpPost("UpdateCompany")]
        public ActionResult<Response<CommonResponse>> UpdateCompany(COMPANY request)
        {
            return Ok(_companyService.UpdateCompany(request));
        }

        [HttpDelete("DeleteCompany")]
        public ActionResult<Response<CommonResponse>> DeleteCompany(int Company_ID)
        {
            return Ok(JsonConvert.SerializeObject(_companyService.DeleteCompany(Company_ID)));
        }

        [HttpGet("GetCompanyVerticals")]
        public ActionResult<Response<List<COMPANY_VERTICALS>>> GetCompanyVerticals()
        {
            return Ok(JsonConvert.SerializeObject(_companyService.GetCompanyVerticals()));
        }


    }
}
