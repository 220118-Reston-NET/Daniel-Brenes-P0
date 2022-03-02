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
        // private readonly ICustomerBL _customerBL;

        public AuthenticationController(IStoreBL p_storeBL) //, ICustomerBL p_customerBL)
        {
            _storeBL = p_storeBL;
            // _customerBL = p_customerBL;
        }

        // [HttpPost("RegisterCustomer")]
        // public IActionResult Register([FromBody] Customer p_customer)
        // {
        //     try
        //     {
        //         // _storeBL.AddCustomer(new Customer(){
        //         //     Name = p_customer.Name,
        //         //     Address = p_customer.Address,
        //         //     Email = p_customer.Email,
        //         //     PhoneNumber = p_customer.PhoneNumber,
        //         //     Wallet = p_customer.Wallet,
        //         //     Pin = p_customer.Pin
        //         // });
        //         Log.Information("Register successful" + p_customer);
        //         return Created("Register successful", _storeBL.AddCustomer(p_customer));
        //     }
        //     catch (System.Exception)
        //     {
        //         Log.Information("Register unsuccessful");
        //         return BadRequest(new {results = "Customer not added"});
        //     }
        // }

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