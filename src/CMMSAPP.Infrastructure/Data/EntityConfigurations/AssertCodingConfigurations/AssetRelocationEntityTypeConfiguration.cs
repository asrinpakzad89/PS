namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssertCodingConfigurations;

public class AssetRelocationEntityTypeConfiguration : IEntityTypeConfiguration<AssetRelocation>
{
    public void Configure(EntityTypeBuilder<AssetRelocation> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date)
            .IsRequired();

        builder.HasOne(x => x.Asset)
        .WithMany(x => x.LocationHistory)
        .HasForeignKey(x => x.AssetId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.FromLocation)
        .WithMany(x => x.RelocationFrom)
        .HasForeignKey(x => x.FromLocationId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ToLocation)
        .WithMany(x => x.RelocationTo)
        .HasForeignKey(x => x.ToLocationId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetRelocations");
    }
}
