using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer_Relationship_Management.Configuration;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {

        builder.HasKey(l => l.Id);
        builder.HasMany(l => l.Contact).WithOne().HasForeignKey(c => c.UserId);
        builder.HasOne(l => l.Seller).WithMany().HasForeignKey(l => l.SaleId);
       
    }
}
