﻿using Microsoft.AspNetCore.Mvc;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazingPizza.Server.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext Context;
        public OrdersController(PizzaStoreContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
        {
            var orders = await Context.Orders.Include(o => o.DeliveryLocation)
                         .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                         .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                         .ThenInclude(t => t.Topping)
                         .OrderByDescending(o => o.CreatedTime)
                         .ToListAsync();

            return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId)
        {
            var order = await Context.Orders.Where(o => o.OrderId == orderId)
                                            .Include(o => o.DeliveryLocation)
                                            .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                                            .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                                            .ThenInclude(t => t.Topping)
                                            .SingleOrDefaultAsync();

            if (order == null)
            {
                return NotFound();
            }

            return OrderWithStatus.FromOrder(order);

        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation = new LatLong(19.0436792069214864, -98.19811254438645);

            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;

                foreach (var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }

            Context.Orders.Attach(order);
            await Context.SaveChangesAsync();

            return order.OrderId;
        }
    }
}