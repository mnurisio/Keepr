

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

    internal List<VaultKeepKeep> GetKeepsInPublicVault(int vaultId)
    {
        string sql = @"
        SELECT
        vault_keeps.*,
        keeps.*,
        accounts.*
        FROM vault_keeps
        JOIN keeps ON keeps.id = vault_keeps.keep_id
        JOIN accounts ON accounts.id = vault_keeps.creator_id
        WHERE vault_keeps.vault_id = @vaultId
        ;";

        List<VaultKeepKeep> keeps = _db.Query(sql, (VaultKeepKeep vaultKeep, Keep keep, Profile account) =>
        {   
            vaultKeep.Creator = account;
            return vaultKeep;
        }, new {vaultId}).ToList();

        return keeps;
    }
}
