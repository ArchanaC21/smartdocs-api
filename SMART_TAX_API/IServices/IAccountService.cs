using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using SMART_TAX_API.Request;
using SMART_TAX_API.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface IAccountService
    {
        Response<string> InsertUser(USER request);

        Response<List<USER>> GetUserList();

        Response<USER> GetUserDetails(string ID);

        Response<string> UpdateUser(USER request);

        Response<string> DeleteUser(string ID);

        AuthenticationResponse AuthenticateUser(AuthenticationRequest request);

        Response<string> InsertUserMaster(List<USER_MASTER> request);

        Response<string> CreateSingleUser(USER_MASTER request);

        Response<List<USER_MASTER>> GetUserMasterList();

        Response<USER_MASTER> GetUserMasterDetails(string ID);

        Response<string> UpdateUserMaster(USER_MASTER request);
    }
}
