using CMMSAPP.Domain.AggregatesModel.AssetLocationCodingAggregate;

namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssetLocationCodingConfigurations;

public class AssetLocationCodingEntityTypeConfiguration : IEntityTypeConfiguration<AssetLocationCoding>
{
    public void Configure(EntityTypeBuilder<AssetLocationCoding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
         .IsRequired()
         .HasMaxLength(200)
         .IsUnicode();

        builder.Property(x => x.Number)
         .IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany(x=>x.AssetocationCodingList)
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LocationCoding)
            .WithMany(x=>x.AssetocationCodingList)
            .HasForeignKey(x => x.LocationCodingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetLocationCodings");
    }
}
