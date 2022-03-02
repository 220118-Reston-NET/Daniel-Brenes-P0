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
        [HttpGet("ViewStoreFrontInventory&OrderHistory")]
        public IActionResult GetAllStoreFrontInventory()
        {
            try
            {
            List<StoreFront> listOfStoreFront = _storeBL.GetAllStoreFront();
            Log.Information("Viewing All StoreFront Inventory & Order History");
                return Ok(_storeBL.GetAllStoreFront());
            }
            catch (SqlException)
            {
                Log.Information("Viewing All Inventory & Order History FAILED");
                return NotFound();
            }
        }

        // PUT: api/StoreFront
        [HttpPut("UpdateInventory")]
        public IActionResult UpdateInventory([FromQueryAttribute] int userId, [FromQueryAttribute] string userPin, [FromQueryAttribute] int newQuantity, [FromQueryAttribute] int storeFrontId, [FromQueryAttribute] int productId)

        {
            Inventory newInventory = new Inventory();
            if (userId >= 5000)
            {
            try
            {
                if(_storeBL.VerifyManager(userId, userPin))
                {
                    Log.Information("Manager Login Success " + userId);
                    newInventory = _storeBL.ReplenishQuantity(newQuantity, storeFrontId, productId);
                    return Ok(_storeBL.ReplenishQuantity(newQuantity, storeFrontId, productId));        
                }
              Log.Information("Manager Login unsuccessful");
              return Ok(newInventory); 
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e);
            }
            }
            else
            {
            Log.Information("Manager Login unsuccessful, not a manager");
                return BadRequest("Not a manager!");
            }
        }
    }
}
