namespace MarkelTask.Api;

public interface IMarkelTaskApi
{
    CompanyModel GetCompany(int id);
    List<ClaimModel> GetClaims(int companyId);
    ClaimModel GetClaim(string ucr);
    bool UpdateClaim(ClaimModel claim);
}

public class MarkelTaskApi(IMarkelTaskRepository repository) : IMarkelTaskApi
{
    public CompanyModel GetCompany(int id)
    {
        // log exceptions and return something more user friendly
        var company = repository.GetCompany(id) ?? throw new ArgumentException($"Company with id {id} not found");

        return ModelHelper.ToCompanyModel(company);
    }

    public List<ClaimModel> GetClaims(int companyId)
    {
        var claims = repository.GetClaims(companyId);
        return claims.Select(ModelHelper.ToClaimModel).ToList();
    }

    public ClaimModel GetClaim(string ucr)
    {
        var claim = repository.GetClaim(ucr) ?? throw new ArgumentException($"Claim with UCR {ucr} not found");

        return ModelHelper.ToClaimModel(claim);
    }

    public bool UpdateClaim(ClaimModel claim)
    {
        // validate any business rules such as dates not in the future...
        if (claim.ClaimDate > DateTime.Now)
        {
            throw new ArgumentException("Claim date cannot be in the future");
        }

        if (claim.LossDate > DateTime.Now)
        {
            throw new ArgumentException("Loss date cannot be in the future");
        }

        repository.UpdateClaim(claim);
        return true;
    }
}