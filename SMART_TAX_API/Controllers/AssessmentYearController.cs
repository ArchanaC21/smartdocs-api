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
    public class AssessmentYearController : ControllerBase
    {
        private IAssessmentYearService _assessmentYearService;
        public AssessmentYearController(IAssessmentYearService assessmentYearService)
        {
            _assessmentYearService = assessmentYearService;
        }

        [HttpPost("InsertAssessmentForm")]
        public ActionResult<Response<string>> InsertAssessmentForm(ASSESSMENT_YEAR_MASTER request)
        {
            return Ok(_assessmentYearService.InsertAssessmentYearForm(request));
        }

        [HttpGet("GetAssYearByCompanyId")]
        public ActionResult<Response<List<ASSESSMENT_YEAR_MASTER>>> GetAssYearByCompanyId(int CompanyID)
        {
            return Ok(JsonConvert.SerializeObject(_assessmentYearService.GetAssYearByCompanyId(CompanyID)));
        }

        [HttpGet("GetAssYearDetails")]
        public ActionResult<Response<ASSESSMENT_YEAR_MASTER>> GetAssYearDetails(int CompanyID, string AssessmentYear)
        {
            return Ok(JsonConvert.SerializeObject(_assessmentYearService.GetAssYearDetails(CompanyID,AssessmentYear)));
        }

        [HttpPost("UpdateAssessmentForm")]
        public ActionResult<Response<string>> UpdateAssessmentForm(ASSESSMENT_YEAR_MASTER request)
        {
            return Ok(_assessmentYearService.UpdateAssessmentYearForm(request));
        }
    }
}
