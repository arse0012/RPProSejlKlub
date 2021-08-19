using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProtoBoatRazorPage.Models;

namespace ProtoBoatRazorPage.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        Dictionary<int, Order> AllOrders();

    }
}
