using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApiLoggingSample.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApiLoggingSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CustomerController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            var existingCustomer = _db.Customers.FirstOrDefault(x => x.Id == customer.Id);

            if (existingCustomer != null)
            {
                return BadRequest($"Customer with ID {customer.Id} already exists");
            }

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return Created($"api/customer/{customer.Id}", customer);
        }

        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            var existingCustomer = _db.Customers.FirstOrDefault(x => x.Id == customer.Id);

            if (existingCustomer == null)
            {
                return BadRequest($"Customer with ID {customer.Id} does not exist");
            }

            existingCustomer.Name = customer.Name;
            _db.SaveChanges();

            return NoContent();
        }
    }
}