namespace HomeworkNinth.Controllers
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using HomeworkNinth.Models;


    // OrderDbContext, OrderDetails, Order, and OrderService classes remain the same.

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;

        public OrdersController(OrderService service)
        {
            _service = service;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _service.DbContext.Orders.ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _service.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            try
            {
                _service.changeOrder(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_service.GetOrderById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            _service.addOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _service.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            _service.deleteOrder(id);
            return NoContent();
        }
    }


}
