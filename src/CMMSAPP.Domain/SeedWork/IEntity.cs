namespace CMMSAPP.Domain.SeedWork;

public interface IEntity<TId>
{
    TId Id { get; }
}
