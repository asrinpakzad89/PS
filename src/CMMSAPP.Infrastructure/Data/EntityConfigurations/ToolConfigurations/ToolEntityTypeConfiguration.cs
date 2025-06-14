namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.ToolConfigurations;

public class ToolEntityTypeConfiguration : IEntityTypeConfiguration<Tool>
{
    public void Configure(EntityTypeBuilder<Tool> builder)
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

        builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(50);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("Tools");
    }
}