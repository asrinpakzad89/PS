namespace CMMSAPP.Domain.AggregatesModel.ToolsAggregate;

public class Tool : Entity, IAggregateRoot
{
    public string Title { get; private set; }
    public string Code { get; private set; }
    public ToolTypeEnum Type { get; private set; }
    public UnitOfMeasureEnum Unit { get; private set; }
    public string? Specification { get; private set; }
    protected Tool() { }

    public Tool(string title, string code, ToolTypeEnum type, UnitOfMeasureEnum unit, string? specification, string? createdBy = null)
    {
        if (!title.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        Id = Guid.NewGuid();

        Title = title;
        Code = code;
        Type = type;
        Unit = unit;
        Specification = specification ?? string.Empty;
        SetCreationInfo(createdBy);
    }

    public void Update(string title, string code, ToolTypeEnum type, UnitOfMeasureEnum unit, string? specification, string? modifiedBy = null)
    {
        if (title.HasValue())
            throw new AssetDomainException("عنوان نمی‌تواند خالی باشد.");

        Title = title;
        Code = code;
        Type = type;
        Unit = unit;
        Specification = specification ?? string.Empty;
        SetModificationInfo(modifiedBy);
    }

    public void Remove(string? modifiedBy = null) => SoftDelete(modifiedBy);
    public void DisableTool(string? modifiedBy = null) => Disable(modifiedBy);
    public void EnableTool(string? modifiedBy = null) => Enable(modifiedBy);
}
