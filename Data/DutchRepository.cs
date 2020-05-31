using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DutchTreat.Data
{
    public class DutchRepository : IDutchRepository
    {
        private readonly DutchContext context;

        public DutchRepository(DutchContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.orders
                .Include(o => o.Items)
                .ThenInclude(o=>o.Product).ToList();
        }
        public Order GetOrderById(int id)
        {
            return context.orders
                .Include(o => o.Items)
                .ThenInclude(o => o.Product).Where(o=>o.Id==id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.products.ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.products.Where(p => p.Category == category).ToList();
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void AddEntity(object model)
        {
            context.Add(model);
        }

        public void AddNewOrder(Order neworder)
        {
            foreach (var item in neworder.Items)
            {
                item.Product = context.products.Find(item.Product.Id);
            }
            AddEntity(neworder);
        }
    }
}
