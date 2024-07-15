namespace MarkelTask.Data;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public bool Active { get; set; }
    public DateTime InsuranceEndDate { get; set; }

    public virtual ICollection<Claim> Claims { get; set; }
}

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.Property(c => c.Name)
            .HasMaxLength(200);
        builder.Property(c => c.Address1)
            .HasMaxLength(100);
        builder.Property(c => c.Address2)
            .HasMaxLength(100);
        builder.Property(c => c.Address3)
            .HasMaxLength(100);
        builder.Property(c => c.PostCode)
            .HasMaxLength(20);
        builder.Property(c => c.Country)
            .HasMaxLength(50);
    }
}
