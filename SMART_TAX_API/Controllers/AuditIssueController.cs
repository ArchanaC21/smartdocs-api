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
    public class AuditIssueController : ControllerBase
    {
        private IAuditService _auditIssueService;
        public AuditIssueController(IAuditService auditIssueService)
        {
            _auditIssueService = auditIssueService;
        }

        [HttpPost("InsertAudit")]
        public ActionResult<Response<string>> InsertAudit(AUDIT_ISSUE request)
        {
            return Ok(_auditIssueService.InsertAudit(request));
        }

        [HttpGet("GetAuditList")]
        public ActionResult<Response<List<AUDIT_ISSUE>>> GetAuditList()
        {
            return Ok(JsonConvert.SerializeObject(_auditIssueService.GetAuditList()));
        }

        [HttpGet("GetDetails")]
        public ActionResult<Response<string>> GetDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_auditIssueService.GetDetails(ID)));
        }

        [HttpPost("UpdateAuditIssue")]
        public ActionResult<Response<string>> UpdateAuditIssue(AUDIT_ISSUE request)
        {
            return Ok(_auditIssueService.UpdateAuditIssue(request));
        }

        [HttpDelete("DeleteAuditIssue")]
        public ActionResult<Response<string>> DeleteAuditIssue(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_auditIssueService.DeleteAuditIssue(ID)));
        }


    }
}

