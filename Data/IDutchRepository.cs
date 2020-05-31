using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using System.Collections.Generic;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        bool SaveChanges();
        void AddEntity(object model);
        void AddNewOrder(Order neworder);
    }
}