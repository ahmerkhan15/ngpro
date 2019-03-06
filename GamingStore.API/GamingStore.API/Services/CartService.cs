﻿using GamingStore.API.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.API.Services
{
    public class CartService
    {
        private readonly IMongoCollection<Orders> _orders;
        //private readonly IMongoCollection<OrderItems> _orderItems;


        public CartService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("GamingStoreDB"));
            var database = client.GetDatabase(config.GetSection("ConnectionStrings").GetSection("Database").Value);
            _orders = database.GetCollection<Orders>("Orders");
            //_orderItems = database.GetCollection<OrderItems>("OrderItems");
        }

        public async Task<Orders> AddToCart(string prodID, decimal quantity, decimal price, string sessionID, string cstID)
        {
            Orders objOrder;
            objOrder = _orders.Find(x => x.sessionID == sessionID).SingleOrDefault();
            if (objOrder == null)
            {
                objOrder = new Orders()
                {
                    date = DateTime.Now,
                    sessionID = sessionID,
                    statusID = 1,
                    total = price,
                    customerID = cstID,
                    items = new List<OrderItems>()
                };
                objOrder.items.Add(new OrderItems { orderID = objOrder.orderID, prodID = prodID, quantity = quantity });
                await _orders.InsertOneAsync(objOrder);
            }
            else
            {
                //objOrder.customerID = cstID;
                objOrder.total += price;
                objOrder.items.Add(new OrderItems { orderID = objOrder.orderID, prodID = prodID, quantity = quantity });
                await _orders.ReplaceOneAsync(x=> x.sessionID == sessionID, objOrder);
            }
            return objOrder;
        }
    }
}
