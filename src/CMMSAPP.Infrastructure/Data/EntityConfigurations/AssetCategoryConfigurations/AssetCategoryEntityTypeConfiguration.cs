namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssetCategoryConfigurations;

public class AssetCategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
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
            .WithMany(x => x.Categories)
            .HasForeignKey(x => x.AssetGroupId);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetCategories");
    }
}
