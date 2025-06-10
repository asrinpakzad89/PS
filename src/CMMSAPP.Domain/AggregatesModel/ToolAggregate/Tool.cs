namespace CMMSAPP.Domain.AggregatesModel.ToolsAggregate;

public class Tool : Entity
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public ToolTypeEnum Type { get; private set; } 
    public UnitOfMeasureEnum Unit { get; private set; } 
    public string? Specification { get; private set; } 
    protected Tool() { }

    public Tool(string name, string code, string? specification, string? createdBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        Name = name;
        Code = code;
        Specification = specification ?? string.Empty;
        SetCreationInfo(createdBy);
    }

    public void Update(string name, string code, string? specification, string? modifiedBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد. لطفاً یک عنوان معتبر وارد کنید.");

        Name = name;
        Code = code;
        Specification = specification ?? string.Empty;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableTool(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableTool(string? modifiedBy = null) => Enable(modifiedBy);
}
