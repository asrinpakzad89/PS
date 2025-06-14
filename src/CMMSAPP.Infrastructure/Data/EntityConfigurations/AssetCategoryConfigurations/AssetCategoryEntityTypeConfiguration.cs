namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssetCategoryConfigurations;

public class AssetCategoryEntityTypeConfiguration : IEntityTypeConfiguration<AssetCategory>
{
    public void Configure(EntityTypeBuilder<AssetCategory> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200)
            .IsUnicode();

        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode();

        builder.HasOne(x => x.AssetGroup)
            .WithMany(x => x.AssetCategoryList)
            .HasForeignKey(x => x.AssetGroupId);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetCategories");
    }
}
