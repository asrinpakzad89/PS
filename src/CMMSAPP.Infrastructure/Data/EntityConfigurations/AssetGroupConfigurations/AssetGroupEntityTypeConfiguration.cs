using CMMSAPP.Domain.AggregatesModel.AssetGroupAggregate;

namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssetGroupConfigurations;

public class AssetGroupEntityTypeConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
       .IsRequired()
       .HasMaxLength(200)
       .IsUnicode();


        builder.HasMany(x=>x.Categories)
            .WithOne(x=>x.AssetGroup)
            .HasForeignKey(x=>x.AssetGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetGroups");
    }
}
