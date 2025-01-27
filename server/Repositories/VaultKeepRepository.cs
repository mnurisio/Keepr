


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
        vault_keeps.*,
        profile_view.*
        FROM vault_keeps
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        WHERE vault_keeps.id = LAST_INSERT_ID();";

        VaultKeep vaultKeep = _db.Query(sql, (VaultKeep vaultKeep, VaultKeepProfile account) => 
        {
            vaultKeep.CreatorId = account.Id;
            return vaultKeep;
        }, vaultKeepData).SingleOrDefault();

        return vaultKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInVault(int vaultId)
    {
        string sql = @"
        SELECT
        vault_keeps.*,
        keeps.*,
        profile_view.*
        FROM vault_keeps
        JOIN keeps ON keeps.id = vault_keeps.keep_id
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        WHERE vault_keeps.vault_id = @VaultId
        ;";

        List<VaultKeepKeep> vaultKeepKeeps = _db.Query(sql, (VaultKeep vaultKeep, VaultKeepKeep keep, VaultKeepProfile account) =>
        {   
            keep.VaultKeepId = vaultKeep.Id;
            keep.VaultId = vaultKeep.VaultId;
            keep.Creator = account;
            return keep;
        }, new {vaultId}).ToList();

        return vaultKeepKeeps;
    }

    internal VaultKeep GetVaultKeepById(int vaultKeepId)
    {
        string sql = @"
        SELECT
        vault_keeps.*,
        profile_view.*
        FROM vault_keeps
        JOIN profile_view ON profile_view.id = vault_keeps.creator_id
        WHERE vault_keeps.id = @vaultKeepId;";

        VaultKeep vaultKeep = _db.Query(sql, (VaultKeep vaultKeep, Profile account) =>
        {
            vaultKeep.CreatorId = account.Id;
            return vaultKeep;
        }, new { vaultKeepId }).SingleOrDefault();

        return vaultKeep;
    }


    internal void DeleteVaultKeep(int vaultKeepId)
    {
        string sql = @"DELETE FROM vault_keeps WHERE vault_keeps.id = @VaultKeepId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { vaultKeepId });

        if (rowsAffected == 0) throw new Exception("DELETE DID NOT AFFECT ANY ROWS");
        if (rowsAffected > 1) throw new Exception("DELETE AFFECTED TOO MANY ROWS");
    }

}
