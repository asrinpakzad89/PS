namespace CMMSAPP.Domain.AggregatesModel.ToolsAggregate;

public class Tool : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public int Type { get; private set; }
    public int Unit { get; private set; }
    public string? Specification { get; private set; }
    protected Tool() { }

    public Tool(string name, string code, ToolTypeEnum type, UnitOfMeasureEnum unit, string? specification, string? createdBy = null)
    {
        if (!name.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        Name = name;
        Code = code;
        Type = type.ToInt();
        Unit = unit.ToInt();
        Specification = specification ?? string.Empty;
        SetCreationInfo(createdBy);
    }

    public void Update(string name, string code, ToolTypeEnum type, UnitOfMeasureEnum unit, string? specification, string? modifiedBy = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        Name = name;
        Code = code;
        Type = type.ToInt();
        Unit = unit.ToInt();
        Specification = specification ?? string.Empty;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableTool(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableTool(string? modifiedBy = null) => Enable(modifiedBy);
}
