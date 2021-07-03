using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infstracture.EFCore.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.Id);

            builder.OwnsMany(x => x.Operations, navigationBuilder =>
            {
                navigationBuilder.ToTable("InventoryOperations");
                navigationBuilder.HasKey(x => x.Id);

                navigationBuilder.Property(x => x.Discription).HasMaxLength(1000).IsRequired();

                navigationBuilder.WithOwner(x=> x.Inventory).HasForeignKey(x => x.InventoryId);
            });
        }
    }
}
