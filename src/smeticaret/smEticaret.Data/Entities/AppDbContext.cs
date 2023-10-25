using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<categoryEntity> Categories { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }
        public DbSet<ProductCommentEntity> ProductComments { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { id = 1, name = "user"},
                 new RoleEntity { id = 2, name = "seller" }
            );
        }
    }
    
}
