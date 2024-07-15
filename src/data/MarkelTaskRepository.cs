namespace MarkelTask.Data;

public interface IMarkelTaskRepository
{
    public Company GetCompany(int id);
    public List<Claim> GetClaims(int companyId);
    public Claim GetClaim(string ucr);
    public Claim UpdateClaim(ClaimModel claim);
}

public class MarkelTaskRepository(MarkelTaskContext context) : IMarkelTaskRepository
{
    public Company GetCompany(int id) => MarkelTaskContext.Company.FirstOrDefault(c => c.Id == id); // would use .Find() for DbSet
    public List<Claim> GetClaims(int companyId) => MarkelTaskContext.Claims.Where(c => c.CompanyId == companyId).ToList();
    public Claim GetClaim(string ucr) => MarkelTaskContext.Claims.FirstOrDefault(c => c.Ucr == ucr);
    public Claim UpdateClaim(ClaimModel claim)
    {
        var dbClaim = GetClaim(claim.Ucr) ?? throw new Exception($"Claim with UCR {claim.Ucr} not found");
        dbClaim.CompanyId = claim.CompanyId;
        dbClaim.ClaimDate = claim.ClaimDate;
        dbClaim.LossDate = claim.LossDate;
        dbClaim.AssuredName = claim.AssuredName;
        dbClaim.IncurredLoss = claim.IncurredLoss;
        dbClaim.Closed = claim.Closed;
        context.SaveChanges();
        return dbClaim;
    }
}