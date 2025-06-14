namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.LocationConfigurations;
public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
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

        builder.HasOne(x => x.Parent)
        .WithMany(x => x.Children)
        .HasForeignKey(x => x.ParentId)
        .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(x => x.RelocationFrom)
        .WithOne(x => x.FromLocation)
        .HasForeignKey(x => x.FromLocationId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.RelocationTo)
        .WithOne(x => x.ToLocation)
        .HasForeignKey(x => x.ToLocationId)
        .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("Locations");
    }
}

