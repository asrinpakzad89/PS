namespace CMMSAPP.Domain.AggregatesModel.AssertCodingAggregate;

public class AssertCoding : Entity, IAggregateRoot
{
    public Guid AssetId { get; private set; }
    public Asset Asset { get; private set; }

    public int FromNumber { get; set; }
    public int ToNumber { get; set; }

    public string Code { get; set; }
}
