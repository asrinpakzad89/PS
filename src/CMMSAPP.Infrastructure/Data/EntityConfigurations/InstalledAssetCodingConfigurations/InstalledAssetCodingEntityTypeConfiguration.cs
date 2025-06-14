namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.InstalledAssetCodeConfigurations;

public class InstalledAssetCodingEntityTypeConfiguration : IEntityTypeConfiguration<InstalledAssetCoding>
{
    public void Configure(EntityTypeBuilder<InstalledAssetCoding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
         .IsRequired()
         .HasMaxLength(150)
         .IsUnicode();

        builder.Property(x => x.Number)
         .IsRequired();


        builder.HasOne(x => x.AssetCoding)
            .WithMany(x=>x.InstalledAssetCodings)
            .HasForeignKey(x => x.AssetCodingId);

        builder.HasOne(x => x.LocationCoding)
            .WithMany(x => x.InstalledAssetCodings)
            .HasForeignKey(x => x.LocationCodingId);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("InstalledAssetCodes");
    }
}
