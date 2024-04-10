using Customer_Relationship_Management.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_Relationship_Management.Configuration;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.HasMany(s => s.Leads).WithOne().HasForeignKey(s => s.SaleId);
        builder.HasOne(s => s.Seller).WithMany(u => u.Sales).HasForeignKey(s => s.SellerId);
   
    }
}
