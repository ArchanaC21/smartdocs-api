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
    public class FormController : ControllerBase
    {
        private IFormService _formService;
        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        [HttpPost("InsertForm")]
        public ActionResult<Response<string>> InsertForm(FORM request)
        {
            return Ok(_formService.InsetForm(request));
        }

        [HttpGet("GetForm")]
        public ActionResult<Response<FORM>> GetForm(int SectionID)
        {
            return Ok(JsonConvert.SerializeObject(_formService.GetFormDetails(SectionID)));
        }
    }
}
