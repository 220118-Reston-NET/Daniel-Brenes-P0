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

        [HttpPost("Register Customers")]
        public IActionResult Register([FromBody] Customer p_customer)
        {
            try
            {
                // _storeBL.AddCustomer(new Customer(){
                //     Name = p_customer.Name,
                //     Address = p_customer.Address,
                //     Email = p_customer.Email,
                //     PhoneNumber = p_customer.PhoneNumber,
                //     Wallet = p_customer.Wallet,
                //     Pin = p_customer.Pin
                // });
                Log.Information("Register successful" + p_customer);
                return Created("Register successful", _storeBL.AddCustomer(p_customer));
            }
            catch (System.Exception)
            {
                Log.Information("Register unsuccessful:" + p_customer);
                Log.Information("With Pin:" + p_customer.Pin);
                return BadRequest(new {results = "Customer not added"});
            }
        }

        // [HttpPost("Login")]
        // public IActionResult Login([FromBody] LoginForm p_loginForm)
        // {
        //     try
        //     {
        //       if(_userBL.Login(new User()
        //       {
        //           UserName = p_loginForm.UserName,
        //           Password = p_loginForm.Password
        //       }))
        //       {
        //             Log.Information("log in success");
        //             return Ok("Login Successful");            
        //       }
        //       return BadRequest("Login failed"); 
        //     }
        //     catch (System.Exception e)
        //     {
              
        //         return StatusCode(500, e);
        //     }
        // }

    }
}