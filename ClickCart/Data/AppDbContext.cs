/*using ClickCart.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickCart.Data
{ 

    public class AppDbContext :DbContext
 {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //عشان احط داتا في الجدول تاعي 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Productsss>().HasData(
            new Productsss { Id = 1, Name = "PowerPlay", Description = "this is PowerPlay" },
            new Productsss { Id = 2, Name = "CleanWave", Description = "this is CleanWave" },
            new Productsss { Id =3, Name = "SnackBox", Description = "this is SnackBox" },
            new Productsss { Id =4, Name = "Printer", Description = "this is Printer" }
                );
            base.OnModelCreating(modelBuilder);
        }
       public DbSet<Productsss> productsss { get; set; }

    }
    
}
*/