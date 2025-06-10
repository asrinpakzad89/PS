using CMMSAPP.Domain.Exceptions;

namespace CMMSAPP.Domain.AggregatesModel.AssetAggregate.Exceptions;

public class AssetDomainException : DomainException
{
    public AssetDomainException() { }
    public AssetDomainException(string message) : base(message) { }
    public AssetDomainException(string message, Exception innerException) : base(message, innerException) { }
}