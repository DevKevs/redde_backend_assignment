using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using reddeApi.Data;
using reddeApi.Entities;

namespace reddeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMongoCollection<Customer> _customers;
        public CustomerController(MongoDbService mongoDbService)
        {
            _customers = mongoDbService.Database?.GetCollection<Customer>("customers") 
                ?? throw new InvalidOperationException("Database not initialized or collection not found.");
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                return await _customers.Find(FilterDefinition<Customer>.Empty).ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer?> GetCustomerById(string id)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
                var customer = _customers.Find(filter).FirstOrDefault();
                return customer is not null ? Ok(customer) : NotFound();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpGet("get-by-document/{document}")]
        public ActionResult<Customer?> GetCustomerByDocument(string document)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq(x => x.Document, document);
                var customer = _customers.Find(filter).FirstOrDefault();
                return customer is not null ? Ok(customer) : NotFound();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            try
            {
                await _customers.InsertOneAsync(customer);
                return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(Customer customer)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
                await _customers.ReplaceOneAsync(filter, customer);
                return Ok(new {success = true, message = "User updated succesfully"});
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(string id)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
                await _customers.DeleteOneAsync(filter);
                return Ok(new { success = true, message = "User deleted succesfully" });
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
