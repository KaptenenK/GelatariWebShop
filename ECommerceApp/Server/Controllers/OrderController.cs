using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        //vi tar bort den här metoden för att låta webhook göra en call och order
        //[HttpPost]
        //public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrder()
        //{
        //    var result = await _orderService.PlaceOrder();
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderOverviewDTO>>>> GetOrders()
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<ServiceResponse<OrderDetailsDTO>>> GetOrderDetails(int orderId)
        {
            var result = await _orderService.GetOrderDetails(orderId);
            return Ok(result);
        }


    }
}
