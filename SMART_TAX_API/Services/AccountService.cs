using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SMART_TAX_API.Helpers;
using SMART_TAX_API.IServices;
using SMART_TAX_API.Models;
using SMART_TAX_API.Repository;
using SMART_TAX_API.Request;
using SMART_TAX_API.Response;
using SMART_TAX_API.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMART_TAX_API.Services
{
    public class AccountService: IAccountService
    {
        private readonly IConfiguration _config;

        public AccountService(IConfiguration config)
        {
            _config = config;
        }

        public AuthenticationResponse AuthenticateUser(AuthenticationRequest request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            AuthenticationResponse response = new AuthenticationResponse();

            var result = DbClientFactory<AccountRepo>.Instance.ValidateUser(dbConn, request.USERNAME, request.PASSWORD);

            if (result == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Credentials for {request.USERNAME} are not valid";
                return response;
            }

            
            response.IsAuthenticated = true;
            response.Id = result.ID;
            response.UserName = result.USERNAME;
            response.Role = result.ROLE;
            response.CompanyId = result.COMPANY_ID;
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        
                        new Claim("role",result.ROLE),
                        new Claim("UserName",result.USERNAME),
                        new Claim("company",result.COMPANY_ID.ToString()),
                        new Claim("expiry", DateTime.Now.AddMinutes(120).ToString("yyyyMMddHHmmss") )
                       
                        };
            response.Token = GenerateJSONWebToken(claims);
            return response;
        }

        public Response<string> DeleteUser(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();

            if (ID == 0)
            {
                response.ResponseCode = 500;
                response.ResponseMessage = "Please provide ID ";
                return response;
            }

            DbClientFactory<AccountRepo>.Instance.DeleteUser(dbConn, ID);

            response.Succeeded = true;
            response.ResponseMessage = "Master deleted Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<USER> GetUserDetails(int ID)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<USER> response = new Response<USER>();
            var data = DbClientFactory<AccountRepo>.Instance.GetUserDetails(dbConn, ID);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<List<USER>> GetUserList()
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<List<USER>> response = new Response<List<USER>>();
            var data = DbClientFactory<AccountRepo>.Instance.GetUserList(dbConn);

            if (data != null)
            {
                response.Succeeded = true;
                response.ResponseCode = 200;
                response.ResponseMessage = "Success";
                response.Data = data;
            }
            else
            {
                response.Succeeded = false;
                response.ResponseCode = 500;
                response.ResponseMessage = "No Data";
            }

            return response;
        }

        public Response<string> InsertUser(USER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            DbClientFactory<AccountRepo>.Instance.InsertUser(dbConn, request);


            Response<string> response = new Response<string>();
            response.Succeeded = true;
            response.ResponseMessage = "Master saved Successfully.";
            response.ResponseCode = 200;

            return response;
        }

        public Response<string> UpdateUser(USER request)
        {
            string dbConn = _config.GetConnectionString("ConnectionString");

            Response<string> response = new Response<string>();
            DbClientFactory<AccountRepo>.Instance.UpdateUser(dbConn, request);

            response.Succeeded = true;
            response.ResponseMessage = "Master updated Successfully.";
            response.ResponseCode = 200;

            return response;
        }


        private string GenerateJSONWebToken(Claim[] claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token =  new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
