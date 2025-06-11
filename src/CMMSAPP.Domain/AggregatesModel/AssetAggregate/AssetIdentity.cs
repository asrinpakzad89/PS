namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate;

public class AssetIdentity : Entity
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public bool IsStandard { get; private set; }

    public Guid ManufacturerId { get; private set; }
    public Manufacturer Manufacturer { get; private set; }

    public string? YearOfManufacture { get; private set; }
    public int? Shape { get; private set; }
    public int? Material { get; private set; }
    public int ImportanceLevel { get; private set; }

    public string? PhysicalLabel { get; private set; }
    public string? SerialNumber { get; private set; }

    public string? FunctionalDescription { get; private set; }


    private readonly List<Dimension>? _dimensions = new();
    public IReadOnlyCollection<Dimension> Dimensions => _dimensions.AsReadOnly();


    public string? TechnicalSpecifications { get; private set; }

    protected AssetIdentity() { }

    public AssetIdentity(Guid assetId, bool isStandard, ImportanceLevelEnum? importanceLevel,
                         Guid manufacturerId, string? yearOfManufacture,
                         ShapeEnum? shape, MaterialTypeEnum? material, string? physicalLabel,
                         string? serialNumber, string? functionalDescription,
                         IEnumerable<Dimension>? dimensions, string? technicalSpecifications)
    {
        if (assetId == null) 
            throw new AssetDomainException("کد تجهیز نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        AssetId = assetId;
        IsStandard = isStandard;
        ManufacturerId = manufacturerId;
        YearOfManufacture = yearOfManufacture;
        Shape = shape?.ToInt() ?? 0;
        Material = material?.ToInt() ?? 0;
        ImportanceLevel = importanceLevel?.ToInt() ?? 0;
        PhysicalLabel = physicalLabel;
        SerialNumber = serialNumber;
        FunctionalDescription = functionalDescription;
        TechnicalSpecifications = technicalSpecifications;
        IsDisabled = false;

        if (dimensions != null)
            _dimensions.AddRange(dimensions);
    }

    public void Update(bool isStandard, ImportanceLevelEnum? importanceLevel,
                       Guid manufacturerId, string? yearOfManufacture,
                       ShapeEnum? shape, MaterialTypeEnum? material, string? physicalLabel,
                       string? serialNumber, string? functionalDescription,
                       IEnumerable<Dimension>? dimensions, string? technicalSpecifications)
    {
        IsStandard = isStandard;
        ManufacturerId = manufacturerId;
        YearOfManufacture = yearOfManufacture;
        Shape = shape?.ToInt() ?? 0;
        Material = material?.ToInt() ?? 0;
        ImportanceLevel = importanceLevel?.ToInt() ?? 0;
        PhysicalLabel = physicalLabel;
        SerialNumber = serialNumber;
        FunctionalDescription = functionalDescription;
        TechnicalSpecifications = technicalSpecifications;

        _dimensions.Clear();
        if (dimensions != null)
            _dimensions.AddRange(dimensions);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void Disable(string? modifiedBy = null) => Disable(modifiedBy);
    public void Enable(string? modifiedBy = null) => Enable(modifiedBy);
}