namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.MaterialConfigurations;

public class MaterialEntityTypeConfiguration : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
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

        builder.Property(x => x.UnitOfMeasure)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("Materials");
    }
}
