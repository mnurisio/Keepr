

namespace keepr.Repositories;

public class VaultKeepRepository
{
    public VaultKeepRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;

    internal VaultKeepKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vault_keeps(keep_id, vault_id, creator_id)
        VALUES(@KeepId, @VaultId, @CreatorId);
        
        SELECT
        vault_keeps.*,
        profile_view.*,
        keeps.*
        FROM vault_keeps
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        JOIN keeps ON keeps.id = vault_keeps.keep_id
        WHERE vault_keeps.id = LAST_INSERT_ID();";

        VaultKeepKeep VaultKeepKeep = _db.Query(sql, (VaultKeep vaultKeep, VaultKeepProfile account, VaultKeepKeep keep) => 
        {
            keep.CreatorId = account.Id;
            keep.Creator = account;
            keep.VaultKeepId = vaultKeep.Id;
            keep.VaultId = vaultKeep.VaultId;
            return keep;
        }, vaultKeepData).SingleOrDefault();

        return VaultKeepKeep;
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
