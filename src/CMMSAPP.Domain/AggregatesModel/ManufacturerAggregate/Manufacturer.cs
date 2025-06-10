namespace CMMSAPP.Domain.AggregatesModel.ManufacturerAggregate;

public class Manufacturer : Entity
{
    public string CompanyName { get; private set; }
    public string Brand { get; private set; }
    public string? Phone { get; private set; }
    public string? Address { get; private set; }
    public string? Email { get; private set; }
    public string? Country { get; private set; }

    private Manufacturer() { }

    public Manufacturer(string companyName, string brand, string? phone,
                        string? address, string? email, string? country)
    {
        CompanyName = companyName;
        Brand = brand;
        Phone = phone;
        Address = address;
        Email = email;
        Country = country;
    }

    public void Update(string companyName, string brand, string? phone,
                       string? address, string? email, string? country)
    {
        CompanyName = companyName;
        Brand = brand;
        Phone = phone;
        Address = address;
        Email = email;
        Country = country;
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);

}

