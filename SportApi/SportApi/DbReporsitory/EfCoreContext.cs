using Microsoft.EntityFrameworkCore;
using SportApi.DbReporsitory.Models;
using System.Collections.Generic;

namespace SportApi.DbReporsitory
{
    public class EfCoreContext : DbContext
    {
        private readonly string _connectionString =
    "Server=MESSTHATYOUWANT;Database=GoodsDataBase;Trusted_Connection=True;";
        public EfCoreContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<GoodsModel> Goods { get; set; }
        public EfCoreContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GoodsModel>().HasData(new List<GoodsModel>
            {
                new GoodsModel
                {
                    Id = 1,
                    Name = "Ball1",
                    Type = Enums.SportType.Football,
                    Price = 100
                },
                 new GoodsModel
                {
                    Id=2,
                    Name = "Ball2",
                    Type = Enums.SportType.Basketball,
                    Price = 150
                },
                  new GoodsModel
                {
                    Id = 3,
                    Name = "Ball3",
                    Type = Enums.SportType.Volleyball,
                    Price = 200
                },
                   new GoodsModel
                {
                    Id = 4,
                    Name = "Sneakers1",
                    Type = Enums.SportType.Football,
                    Price = 90
                },
                   new GoodsModel
                {
                    Id = 5,
                     Name = "Sneakers",
                    Type = Enums.SportType.Basketball,
                    Price = 90
                },
                   new GoodsModel
                {
                    Id = 6,
                     Name = "Sneakers1",
                    Type = Enums.SportType.Football,
                    Price = 90
                },
            });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }
}
