using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoBoatRazorPage.Helpers;
using ProtoBoatRazorPage.Interfaces;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Repository
{
    public class JsonOrderRepository: IOrderRepository
    {
        string JsonFileName = @"Data\JsonOrder.json";
        public void AddOrder(Order order)
        {
            Dictionary<int, Order> orders = AllOrders();
            List<int> orderIds = new List<int>();
            foreach (var ord in orders)
            {
                orderIds.Add(ord.Value.Code);
            }
            if (orderIds.Count != 0)
            {
                int start = orderIds.Max();
                order.Code = start + 1;
            }
            else
            {
                order.Code = 0;
            }
            orders.Add(order.Code, order);
            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }

        public Dictionary<int, Order> AllOrders()
        {
            Dictionary<int, Order> returnOrders = JsonFileReader.ReadJsonOrder(JsonFileName);
            return returnOrders;
        }
    }
}
