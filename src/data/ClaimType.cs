namespace MarkelTask.Data;

public class ClaimType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ClaimTypeConfiguration : IEntityTypeConfiguration<ClaimType>
{
    public void Configure(EntityTypeBuilder<ClaimType> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(20);
    }
}
