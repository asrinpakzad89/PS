namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.ManufacturerConfigurations;

public class ManufacturerEntityTypeConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyName)
        .IsRequired()
        .HasMaxLength(100)
        .IsUnicode();

        builder.Property(x => x.Brand)
        .HasMaxLength(100);

        builder.Property(x => x.Phone)
        .HasMaxLength(20);

        builder.Property(x => x.Email)
        .HasMaxLength(20);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("Manufacturers");
    }
}
