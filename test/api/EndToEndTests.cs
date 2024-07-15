namespace MarkelTask.Api.Test;

// wouldn't normally test end to end, but considering how small the application is, this is what I've got
public class EndToEndTests
{
    private readonly IMarkelTaskApi _api = new MarkelTaskApi(new MarkelTaskRepository(new MarkelTaskContext()));

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    public void ActiveInsurancePolicyCalculated(int companyId, bool activeInsurancePolicy)
    {
        var company = _api.GetCompany(companyId);

        Assert.Equal(companyId, company.Id);
        Assert.Equal(activeInsurancePolicy, company.ActiveInsurancePolicy);
    }

    [Fact]
    public void CompanyNotFoundThrowsError()
    {
        Assert.Throws<ArgumentException>(() => _api.GetCompany(3));
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 1)]
    public void GetClaims(int companyId, int claimCount)
    {
        var claims = _api.GetClaims(companyId);

        Assert.Equal(claimCount, claims.Count);
    }

    [Theory]
    [InlineData("UCR1", 10)]
    [InlineData("UCR2", 8)]
    [InlineData("UCR3", 6)]
    public void GetClaim(string ucr, int ageInDays)
    {
        var claim = _api.GetClaim(ucr);

        Assert.Equal(ucr, claim.Ucr);
        Assert.Equal(ageInDays, claim.AgeInDays);
    }
    
    [Fact]
    public void ClaimNotFoundThrowsError()
    {
        Assert.Throws<ArgumentException>(() => _api.GetClaim("UCR4"));
    }

    [Fact]
    public void FutureClaimDateThrowsError()
    {
        var claim = _api.GetClaim("UCR1");
        claim.ClaimDate = DateTime.Now.AddDays(1);

        Assert.Throws<ArgumentException>(() => _api.UpdateClaim(claim));
    }

    [Fact]
    public void FutureLossDateThrowsError()
    {
        var claim = _api.GetClaim("UCR1");
        claim.LossDate = DateTime.Now.AddDays(1);

        Assert.Throws<ArgumentException>(() => _api.UpdateClaim(claim));
    }
}