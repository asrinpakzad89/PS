namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssertCodingConfigurations;

public class AssetDimensionEntityTypeConfiguration : IEntityTypeConfiguration<AssetDimension>
{
    public void Configure(EntityTypeBuilder<AssetDimension> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
        .IsRequired();

        builder.HasOne(x => x.Asset)
        .WithMany(x=>x.Dimensions)
        .HasForeignKey(x => x.AssetId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Dimension)
        .WithMany(x=>x.AssetDimensions)
        .HasForeignKey(x => x.DimensionId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetDimensions");
    }
}

