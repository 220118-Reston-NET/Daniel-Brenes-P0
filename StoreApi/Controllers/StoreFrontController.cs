using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StoreModel;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IStoreBL _storeBL;
        public StoreFrontController(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        // GET: api/StoreFront
        [HttpGet("ViewStoreFrontInventory")]
        public IActionResult GetAllStoreFrontInventory()
        {
            try
            {
            List<StoreFront> listOfStoreFront = _storeBL.GetAllStoreFront();
            Log.Information("Viewing All Inventory");
                return Ok(_storeBL.GetAllStoreFront());
            }
            catch (SqlException)
            {
                Log.Information("Viewing All Inventory FAILED");
                return NotFound();
            }
        }
        // GET: api/Customer/5
        [HttpGet("DisplayStoreFrontOrders")]
        public IActionResult GetCustomerOrderById([FromQueryAttribute] int customerId)
        {
            try
            {
            List<Order> listOfOrder = new List<Order>();
            // listOfOrder =  _storeBL.GetOrderByCustomerId(customerId);
            Log.Information("Displaying Customer Orders " + customerId);
                return Ok(_storeBL.GetOrderByCustomerId(customerId));
            }
            catch (SqlException)
            {
                 Log.Information("Displaying FAILED " + customerId);
                return NotFound();
            }
        }
        // PUT: api/Customer/5
        // [HttpPut("Update/{id}")]
        // public IActionResult Put(int id, [FromBody] Customer p_customer)
        // {
        //     p_customer.CustomerId = id;
        //     try
        //     {
        //         return Ok(_storeBL.UpdateCustomer(p_customer));
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return Conflict(ex.Message);
        //     }
        // }
    }
}
