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


        builder.HasOne(x => x.AssertCoding)
            .WithMany(x=>x.InstalledAssetCodingList)
            .HasForeignKey(x => x.AssertCodingId);

        builder.HasOne(x => x.Location)
            .WithMany(x => x.InstalledAssetCodingList)
            .HasForeignKey(x => x.LocationId);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("InstalledAssetCodes");
    }
}
