﻿using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ECommerceApp.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        private readonly ICartService _cartService;
        private readonly IAuthservice _authService;

        public OrderService(DataContext context, ICartService cartService, IAuthservice authService)
        {
            _context = context;
            _cartService = cartService;
            _authService = authService;
            
        }

        public async Task<ServiceResponse<OrderDetailsDTO>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsDTO>();
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.ProductType)
                .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
                .OrderByDescending(o => o.OrderDate)
                .FirstOrDefaultAsync(); 
            if(order == null)
            {
                response.Success = false;
                response.Message = "Hittade inte beställningen :'( ...";
                return response;             
            }

            var orderDetailsResponse = new OrderDetailsDTO
            {
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Products = new List<OrderDetailsProductDTO>()
            };

            order.OrderItems.ForEach(item => orderDetailsResponse.Products.Add(new OrderDetailsProductDTO
            {
                ProductId = item.ProductId,
                ImageUrl = item.Product.ImageUrl,
                ProductType = item.ProductType.Name,
                Quantity = item.Quantity,
                Title = item.Product.Title,
                TotalPrice = item.TotalPrice,
            }));

            response.Data = orderDetailsResponse;
            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewDTO>>> GetOrders()
        {
           var response = new ServiceResponse<List<OrderOverviewDTO>>();
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Where(o => o.UserId == _authService.GetUserId())
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            var orderResponse = new List<OrderOverviewDTO>();
            orders.ForEach(o => orderResponse.Add(new OrderOverviewDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                TotalPrice = o.TotalPrice,
                Product = o.OrderItems.Count > 1 ? $"{o.OrderItems.First().Product.Title} och " + $"{o.OrderItems.Count - 1} till" : o.OrderItems.First().Product.Title,
                ProductImageUrl = o.OrderItems.First().Product.ImageUrl
            }));
            response.Data = orderResponse;
            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int userId)
        {
            //få produkter från en authenticated users kundvagn
            var products = (await _cartService.GetDbCartProducts(userId)).Data;
            decimal totalPrice = 0;
            products.ForEach(product=> totalPrice+= product.Price * product.Quantity);


            //skapa en lista av items
            var orderItems = new List<OrderItem>();
            products.ForEach(product => orderItems.Add(new OrderItem
            {

                ProductId = product.ProductId,
                ProductTypeId = product.ProductTypeId,
                Quantity= product.Quantity,
                TotalPrice= product.Price * product.Quantity,
            }));
            //skapa en order
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            //lägga till vår order till table
            _context.Orders.Add(order);


            //För att tömma orderlistan
            _context.CartItems.RemoveRange(_context.CartItems
                .Where(ci => ci.UserId == userId));
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true }; 
       }

       
    }
}
