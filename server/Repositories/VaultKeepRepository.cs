namespace keepr.Repositories;

public class VaultKeepRepository
{
    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;
}
