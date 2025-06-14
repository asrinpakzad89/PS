using CMMSAPP.Domain.AggregatesModel.VisitAggregate;

namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.VisitConfigurations;

class VisitEntityTypeConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
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


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("Visits");
    }
}