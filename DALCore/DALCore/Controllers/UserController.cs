using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService;
using Core.Contracts;
using GuardService;
using Core.Contracts.Models;
using Newtonsoft.Json.Linq;

namespace DALCore.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserAuthentication admin;
        public UserController(IUserAuthentication _admin)
        {
            admin = _admin;
        }
        [HttpPut]
        [Route("api/[controller]/Login")]
        public bool ValidateUser([FromBody]LoginBasicDetails loginBasicDetails)
        {
            if (admin.UserValidation(loginBasicDetails.UserId, loginBasicDetails.Password))
            {
                GuardManager log = new GuardManager();
                string response = log.AddGuardLogAtLogin(loginBasicDetails.UserId);
                if (response.Equals("Logged Successfully"))
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPut]
        [Route("api/[controller]/Logout")]
        public bool AddLogoutLog([FromBody]SearchFilter GuardId)
        {
            GuardManager log = new GuardManager();
            string response = log.EditGuardLogAtLogOut(GuardId.UserInput);
            if (response.Equals("Logged Successfully"))
            {
                return true;
            }
            return false;
        }
    }
}