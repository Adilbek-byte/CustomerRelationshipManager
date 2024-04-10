using Customer_Relationship_Management.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_Relationship_Management.Configuration;

public class UserConfiguraion : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
       
        builder.HasMany(u => u.Contacts).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        builder.HasMany(u => u.Sales).WithOne(s => s.Seller).HasForeignKey(s => s.SellerId);
        builder.HasMany(u => u.Leads).WithOne().HasForeignKey(l => l.SaleId);
       
    }
}
