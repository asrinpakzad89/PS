namespace CMMSAPP.Infrastructure.Data;

public class ApplicationDBContext : DbContext, IUnitOfWork
{
    #region DbSet
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetDimension> AssetDimensions { get; set; }
    public DbSet<AssetIdentity> AssetIdentities { get; set; }
    public DbSet<AssetRelocation> AssetRelocations { get; set; }
    public DbSet<AssetStatus> AssetStatuses { get; set; }
    public DbSet<Category> AssetCategories { get; set; }
    public DbSet<AssetCoding> AssetCodings { get; set; }
    public DbSet<Group> AssetGroups { get; set; }
    public DbSet<AssetTreeStructure> AssetTreeStructures { get; set; }
    public DbSet<Breakdown> Breakdowns { get; set; }
    public DbSet<Dimension> Dimensions { get; set; }
    public DbSet<FileResource> FileResources { get; set; }
    public DbSet<InstalledAssetCoding> InstalledAssetCodings { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationCoding> LocationCodings { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<StandardPart> StandardParts { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Visit> Visits { get; set; }
    #endregion

    private readonly IMediator _mediator;
    private IDbContextTransaction _currentTransaction;

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

    public bool HasActiveTransaction => _currentTransaction != null;

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));


        System.Diagnostics.Debug.WriteLine("ApplicationDBContext::ctor ->" + this.GetHashCode());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));
        if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
