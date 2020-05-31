using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext context;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<StoreUser> userManager;

        public DutchSeeder(DutchContext context, IWebHostEnvironment hosting,UserManager<StoreUser>userManager)
        {
            this.context = context;
            this.hosting = hosting;
            this.userManager = userManager;
        }
        public async  Task SeedAsync()
        {
            context.Database.EnsureCreated();
            StoreUser user = await userManager.FindByEmailAsync("Taher@gmail.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Taher",
                    LastName = "Tito",
                    Email = "Taher@gmail.com",
                    UserName = "Taher@gmail.com"
                };
               var result= await userManager.CreateAsync(user, "TaherTito123!");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Faild on creating a user");
                }

            }

            if (!context.products.Any())//if there aren't any products 
            {
                //then we need to create sample data

                var artJsonPath = Path.Combine(hosting.ContentRootPath + "/Data/art.json");

                var jsonContent = File.ReadAllText(artJsonPath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(jsonContent);
                context.products.AddRange(products);
                var order = context.orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {
                   // order.storeUser = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem(){
                         Product = products.First(),
                         Quantity=5,
                         UnitPrice=products.First().Price
                        }
                    };
                }


                context.SaveChanges();


            }
        }
    }
}
