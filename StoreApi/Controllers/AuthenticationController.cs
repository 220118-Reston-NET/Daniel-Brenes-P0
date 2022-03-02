using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreModel;


namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {   
        private readonly IStoreBL _storeBL;
        public AuthenticationController(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromQueryAttribute] int userId, [FromQueryAttribute] string userPin)
        {
            if (userId >= 5000)
            {
            try
            {
                if(_storeBL.VerifyManager(userId, userPin))
              {
                    Log.Information("Manager Login Success" + userId);
                    return Ok("Manager Login Successful");            
              }
              Log.Information("Manager Login unsuccessful");
              return BadRequest("Login failed"); 
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
            }
            else
            {
            try
            {
              if(_storeBL.VerifyCustomer(userId, userPin))
              {
                    Log.Information("Customer Login Success" + userId);
                    return Ok("Customer Login Successful");            
              }
              Log.Information("Customer Login unsuccessful");
              return BadRequest("Customer Login failed"); 
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
            }
        }
    }
}