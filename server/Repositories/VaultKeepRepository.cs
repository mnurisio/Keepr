
namespace keepr.Repositories;

public class VaultKeepRepository
{
    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vault_keeps(keep_id, vault_id, creator_id)
        VALUES(@KeepId, @VaultId, @CreatorId);
        
        SELECT
        vault_keeps.*
        FROM vault_keeps
        WHERE vault_keeps.id = LAST_INSERT_ID();";

        VaultKeep VaultKeep = _db.Query<VaultKeep>(sql, vaultKeepData).SingleOrDefault();

        return VaultKeep;
    }
}
