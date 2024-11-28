using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using u20201b510_tallercito.SCM.Domain.Model.Aggregate;
using u20201b510_tallercito.SD.Domain.Model.Aggregate;
using u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace u20201b510_tallercito.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
   protected override void OnConfiguring(DbContextOptionsBuilder builder)
   {
      //Para campos de auditor (CreatedDate, UpdatedDate)
      builder.AddCreatedUpdatedInterceptor();
      base.OnConfiguring(builder);
   }
   
   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      
      //=================================================================================================
      //||                                    CONFIGURATION OF THE TABLES                              ||                              
      //=================================================================================================
      
      builder.Entity<InventoryItem>().HasKey(i => i.Id);
      builder.Entity<InventoryItem>().Property(i => i.Id).ValueGeneratedOnAdd();
      //=================================================================================================
      
      builder.Entity<InventoryItem>().Property(i => i.ProductSku).IsRequired();
      builder.Entity<InventoryItem>().Property(i => i.Status).IsRequired();
      builder.Entity<InventoryItem>().Property(i => i.MinimumQuantity).IsRequired();
      builder.Entity<InventoryItem>().Property(i => i.AvailableQuantity).IsRequired();
      builder.Entity<InventoryItem>().Property(i => i.ReservedQuantity);
      builder.Entity<InventoryItem>().Property(i => i.PendingSupplyQuantity);
      
      
      //=================================================================================================
      builder.Entity<OrderItem>().HasKey(o => o.Id);
      builder.Entity<OrderItem>().Property(o => o.Id).ValueGeneratedOnAdd();
      //=================================================================================================
      
      builder.Entity<OrderItem>().Property(o => o.OrderId).IsRequired();
      builder.Entity<OrderItem>().Property(o => o.ProductSku).IsRequired();
      builder.Entity<OrderItem>().Property(o => o.RequestedQuantity).IsRequired();
      builder.Entity<OrderItem>().Property(o => o.OrderedAt).IsRequired();
      builder.Entity<OrderItem>().Property(o => o.Status);
      
      
      
      //Regals de mapped object relational (ORM)
      builder.UseSnakeCaseNamingConvention();
   }
}