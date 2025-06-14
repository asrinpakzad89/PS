using CMMSAPP.Domain.AggregatesModel.AssetTreeStructureAggregate;

namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssetTreeStructureConfigurations;

public class AssetTreeStructureEntityTypeConfiguration : IEntityTypeConfiguration<AssetTreeStructure>
{
    public void Configure(EntityTypeBuilder<AssetTreeStructure> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.InstalledAssetCoding)
            .WithMany(x=>x.AssetTreeStructures)
            .HasForeignKey(x => x.InstalledAssetCodingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Level)
            .WithMany(x=>x.AssetTreeStructures)
            .HasForeignKey(x => x.LevelId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetTreeStructures");
    }
}
