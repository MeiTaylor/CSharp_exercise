using HomeworkNinth.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HomeworkNinth.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=orderdb;user=root;password=Nkp030119+;",
                ServerVersion.AutoDetect("server=localhost;database=orderdb;user=root;password=Nkp030119+;"));
        }
    }


}
