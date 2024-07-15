
namespace MarkelTask.Model;

public class CompanyModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public bool Active { get; set; }
    public bool ActiveInsurancePolicy { get; set; }
}