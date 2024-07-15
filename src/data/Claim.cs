namespace MarkelTask.Data;

public class Claim
{
    public string Ucr { get; set; }
    public int CompanyId { get; set; }
    public DateTime ClaimDate { get; set; }
    public DateTime LossDate { get; set; }
    public string AssuredName { get; set; }
    public decimal IncurredLoss { get; set; }
    public bool Closed { get; set; }

    public virtual Company Company { get; set; }
}

public class ClaimConfiguration : IEntityTypeConfiguration<Claim>
{
    public void Configure(EntityTypeBuilder<Claim> builder)
    {
        builder.Property(c => c.Ucr)
            .HasMaxLength(20);
        builder.Property(c => c.AssuredName)
            .HasColumnName("Assured Name")
            .HasMaxLength(100);
        builder.Property(c => c.IncurredLoss)
            .HasColumnName("Incurred Loss")
            .HasPrecision(15, 2);
    }
}