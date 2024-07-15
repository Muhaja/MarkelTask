namespace MarkelTask.Api;

public static class ModelHelper
{
    public static ClaimModel ToClaimModel(this Claim claim)
    {
        return new ClaimModel
        {
            Ucr = claim.Ucr,
            CompanyId = claim.CompanyId,
            ClaimDate = claim.ClaimDate,
            LossDate = claim.LossDate,
            AssuredName = claim.AssuredName,
            IncurredLoss = claim.IncurredLoss,
            Closed = claim.Closed,
            AgeInDays = (DateTime.Now - claim.ClaimDate).Days
        };
    }

    public static CompanyModel ToCompanyModel(this Company company)
    {
        return new CompanyModel
        {
            Id = company.Id,
            Name = company.Name,
            Address1 = company.Address1,
            Address2 = company.Address2,
            Address3 = company.Address3,
            PostCode = company.PostCode,
            Country = company.Country,
            Active = company.Active,
            ActiveInsurancePolicy = company.InsuranceEndDate > DateTime.Now
        };
    }
}