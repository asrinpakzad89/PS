namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssertCodingConfigurations;

public class AssetIdentityEntityTypeConfiguration : IEntityTypeConfiguration<AssetIdentity>
{
    public void Configure(EntityTypeBuilder<AssetIdentity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Manufacturer)
            .WithMany()
            .HasForeignKey(x => x.ManufacturerId);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetIdentities");
    }
}
