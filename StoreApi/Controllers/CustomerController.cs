using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class CustomerController : ControllerBase
    {
        private IStoreBL _storeBL;
        public CustomerController(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        // GET: api/Customer
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {
            try
            {
                return Ok(await _storeBL.GetAllCustomerAsync());
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

        // GET: api/Customer/5
        [HttpGet("GetCustomerByName/{customerName}")]
        public IActionResult GetCustomerByName(string customerName)
        {
            try
            {
                return Ok(_storeBL.SearchCustomerByName(customerName));
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Customer p_customer)
        {
            try
            {
                return Created("Successfully added", _storeBL.AddCustomer(p_customer));
            }
            catch(System.Exception)
            {
                return Conflict();
            }
            // return Ok(_storeBL.AddCustomer(p_customer));
        }

        // PUT: api/Customer/5
        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] Customer p_customer)
        {
            p_customer.CustomerId = id;
            try
            {
                return Ok(_storeBL.UpdateCustomer(p_customer));
            }
            catch (System.Exception ex)
            {
                return Conflict(ex.Message);
            }

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
