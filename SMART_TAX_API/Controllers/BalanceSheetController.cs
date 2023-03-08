using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class BalanceSheetController : ControllerBase
    {
        private IBalanceSheetService _balanceSheetService;
        public BalanceSheetController(IBalanceSheetService balanceSheetService)
        {
            _balanceSheetService = balanceSheetService;
        }

        [HttpPost("InsertBalanceSheetForm")]
        public ActionResult<Response<string>> InsertBalanceSheetForm(BALANCE_SHEET request)
        {
            return Ok(_balanceSheetService.InsertBalanceSheetForm(request));
        }
    }
}
