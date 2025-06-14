namespace CMMSAPP.Infrastructure.Data.EntityConfigurations.LevelConfigurations;

public class LevelEntityTypeConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
         .IsRequired()
         .HasMaxLength(150)
         .IsUnicode();

        builder.Property(x => x.Code)
         .IsRequired()
         .HasMaxLength(50)
         .IsUnicode();

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasQueryFilter(x => !x.IsDelete);
        builder.ToTable("InstalledAssetCodings");
    }
}
