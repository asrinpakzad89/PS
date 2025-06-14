namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssertCodingConfigurations;

public class AssetStatusEntityTypeConfiguration : IEntityTypeConfiguration<AssetStatus>
{
    public void Configure(EntityTypeBuilder<AssetStatus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Status)
            .IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany(x=>x.StatusHistory)
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssetStatus");
    }
}
