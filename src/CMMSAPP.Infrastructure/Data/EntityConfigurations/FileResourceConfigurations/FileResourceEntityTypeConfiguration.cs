using CMMSAPP.Domain.AggregatesModel.FileResourceAggregate;

namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.FileResourceConfigurations;

public class FileResourceEntityTypeConfiguration : IEntityTypeConfiguration<FileResource>
{
    public void Configure(EntityTypeBuilder<FileResource> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
         .IsRequired()
         .HasMaxLength(150)
         .IsUnicode();

        builder.Property(x => x.FilePath)
         .IsRequired()
         .HasMaxLength(500)
         .IsUnicode();

        builder.Property(x => x.OwnerType)
         .HasMaxLength(50)
         .IsRequired();


        builder.Property(x => x.OwnerId)
            .IsRequired();


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("FileResources");
    }
}
