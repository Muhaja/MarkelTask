namespace MarkelTask.Data;

public class MarkelTaskContext : DbContext
{
    // public DbSet<Claim> Claims { get; set; }
    // public DbSet<ClaimType> ClaimType { get; set; }
    // public DbSet<Company> Company { get; set; }

    public static List<Claim> Claims => [
        new Claim
        {
            Ucr = "UCR1",
            CompanyId = 1,
            ClaimDate = DateTime.Today.AddDays(-10),
            LossDate = DateTime.Today.AddDays(-9),
            AssuredName = "Assured 1",
            IncurredLoss = 1000,
            Closed = false
        },
        new Claim
        {
            Ucr = "UCR2",
            CompanyId = 1,
            ClaimDate = DateTime.Today.AddDays(-8),
            LossDate = DateTime.Today.AddDays(-7),
            AssuredName = "Assured 2",
            IncurredLoss = 2000,
            Closed = true
        },
        new Claim
        {
            Ucr = "UCR3",
            CompanyId = 2,
            ClaimDate = DateTime.Today.AddDays(-6),
            LossDate = DateTime.Today,
            AssuredName = "Assured 3",
            IncurredLoss = 3000,
            Closed = false
        }
    ];

    public static List<ClaimType> ClaimType => [];

    public static List<Company> Company => [
        new Company
        {
            Id = 1,
            Name = "Company 1",
            Address1 = "Address 1",
            Address2 = "Address 2",
            Address3 = "Address 3",
            PostCode = "Post Code",
            Country = "Country",
            Active = true,
            InsuranceEndDate = DateTime.Today.AddDays(10)
        },
        new Company
        {
            Id = 2,
            Name = "Company 2",
            Address1 = "Address 1",
            Address2 = "Address 2",
            Address3 = "Address 3",
            PostCode = "Post Code",
            Country = "Country",
            Active = true,
            InsuranceEndDate = DateTime.Today.AddDays(-20)
        }
    ];
}