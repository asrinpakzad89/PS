namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.LocationCodingConfigurations;

public class LocationCodingEntityTypeConfiguration : IEntityTypeConfiguration<LocationCoding>
{
    public void Configure(EntityTypeBuilder<LocationCoding> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode();

        builder.HasOne(x => x.Location)
        .WithMany(x=>x.LocationCodingList)
        .HasForeignKey(x => x.LocationId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("LocationCodings");
    }
}
