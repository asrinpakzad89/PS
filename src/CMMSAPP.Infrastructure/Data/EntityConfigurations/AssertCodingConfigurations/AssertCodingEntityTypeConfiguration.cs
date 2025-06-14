namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.AssertCodingConfigurations;

public class AssertCodingEntityTypeConfiguration : IEntityTypeConfiguration<AssetCoding>
{
    public void Configure(EntityTypeBuilder<AssetCoding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Asset)
            .WithMany()
            .HasForeignKey(x => x.AssetId);

        builder.Property(x => x.FromNumber)
            .IsRequired();

        builder.Property(x => x.ToNumber)
            .IsRequired();


        builder.HasOne(x=>x.Asset)
            .WithMany(x=>x.Codings)
            .HasForeignKey(x=>x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("AssertCodings");
    }
}
