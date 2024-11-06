using ClickCart.Core.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Infrastructure.Data
{
    public class AppDbContext:IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//primery key
            modelBuilder.Entity<OrderDetails>()
            .HasKey(x =>new { x.Id,x.Product_Id,x.Order_Id});
            modelBuilder.Entity<Categoiers>().HasData(
           new Categoiers { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
           new Categoiers { Id = 2, Name = "Books", Description = "Books and literature" },
           new Categoiers { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
);

           /* modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Thara'a Shehadeh", Username = "Shehadeh12345", Password = "password123", Role = "Admin" },
                new User { Id = 2, Name = "Batool Shehadeh", Username = "Shehadeh111", Password = "password456", Role = "User" }
            );*/

            modelBuilder.Entity<Productsss>().HasData(
                new Productsss { Id = 1, Name = "Smartphone", price = 299.99m, Image = "smartphone.jpg", Category_Id = 1 },
                new Productsss { Id = 2, Name = "Laptop", price = 799.99m, Image = "laptop.jpg", Category_Id = 1 },
                new Productsss { Id = 3, Name = "Novel", price = 19.99m, Image = "novel.jpg", Category_Id = 2 },
                new Productsss { Id = 4, Name = "T-Shirt", price = 9.99m, Image = "tshirt.jpg", Category_Id = 3 },
                new Productsss { Id = 5, Name = "Jeans", price = 49.99m, Image = "jeans.jpg", Category_Id = 3 }
            );

            modelBuilder.Entity<Orders>().HasData(
                new Orders { Id = 1, OrderStatus = "Pending", OrderDate = new DateTime(2023, 12, 11) }, //UserId = 1 },
                new Orders { Id = 2, OrderStatus = "Completed", OrderDate = new DateTime(2023, 12, 12) }, //UserId = 2 },
                new Orders { Id = 3, OrderStatus = "Shipped", OrderDate = new DateTime(2023, 12, 13) }); //UserId = 1 }
           
            modelBuilder.Entity<OrderDetails>().HasData(
                new OrderDetails { Id = 1, Order_Id = 1, Product_Id = 1, Price = 299.99m, Qauntity = 1 },
                new OrderDetails { Id = 2, Order_Id = 1, Product_Id = 4, Price = 9.99m, Qauntity = 2 },
                new OrderDetails { Id = 3, Order_Id = 2, Product_Id = 3, Price = 19.99m, Qauntity = 1 },
                new OrderDetails { Id = 4, Order_Id = 3, Product_Id = 2, Price = 799.99m, Qauntity = 1 },
                new OrderDetails { Id = 5, Order_Id = 3, Product_Id = 5, Price = 9.99m, Qauntity = 1 }
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Productsss> Productsss { get; set; }
        public DbSet<Categoiers> Categoiers { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Orders> Orders { get; set; }

       //   public DbSet<IdentityUser> identityuser { get; set; }
       // public DbSet<IdentityRole> identityrole { get; set; }

    }
}
