using Microsoft.EntityFrameworkCore;
using DutchTreat.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DutchTreat.Data
{
    public class DutchContext : IdentityDbContext<StoreUser>
    {
        public DutchContext(DbContextOptions<DutchContext> options) : base(options)
        {

        }
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if(modelBuilder!=null)
             modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id=1,
                    OrderDate=DateTime.UtcNow,
                    OrderNumber="12345"

                }
                 );

        }


    }
}
