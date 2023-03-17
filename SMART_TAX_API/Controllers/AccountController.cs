using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using SMART_TAX_API.Request;
using SMART_TAX_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
     
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("InsertUser")]
        public ActionResult<Response<string>> InsertUser(USER request)
        {
            return Ok(_accountService.InsertUser(request));
        }

        [HttpGet("GetUserList")]
        public ActionResult<Response<List<USER>>> GetUserList()
        {
            return Ok(JsonConvert.SerializeObject(_accountService.GetUserList()));
        }

        [HttpGet("GetUserDetails")]
        public ActionResult<Response<USER>> GetUserDetails(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_accountService.GetUserDetails(ID)));
        }

        [HttpPut("UpdateUser")]
        public ActionResult<Response<string>> UpdateUser(USER request)
        {
            return Ok(_accountService.UpdateUser(request));
        }

        [HttpDelete("DeleteUser")]
        public ActionResult<Response<string>> DeleteUser(int ID)
        {
            return Ok(JsonConvert.SerializeObject(_accountService.DeleteUser(ID)));
        }

        [HttpPost("Authenticate")]
        public ActionResult<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(_accountService.AuthenticateUser(request));
        }

    }
}
