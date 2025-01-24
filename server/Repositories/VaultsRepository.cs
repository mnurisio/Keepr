


namespace keepr.Repositories;


public class VaultsRepository
{

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;

    internal Vault CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO
        vaults(name, description, is_private, img, creator_id)
        VALUES(@Name, @Description, @IsPrivate, @Img, @CreatorId);

        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creator_id
        WHERE vaults.id = LAST_INSERT_ID();";

        Vault vault = _db.Query(sql, (Vault vault, Profile account) =>
        {
            vault.Creator = account;
            return vault;
        }, vaultData).SingleOrDefault();

        return vault;
    }

    internal Vault GetVaultById(int vaultId)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creator_id
        WHERE vaults.id = @VaultId;";

        Vault vault = _db.Query(sql, (Vault vault, Profile account) => 
        {
            vault.Creator = account;
            return vault;
        }, new {vaultId}).SingleOrDefault();

        return vault;
    }

    internal void UpdateVault(Vault vaultData)
    {
        string sql = @"
        UPDATE vaults
        SET
        name = @Name,
        is_private = @IsPrivate
        WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, vaultData);

        if(rowsAffected == 0) throw new Exception("UPDATE DID NOT AFFECT ANY ROWS");
        if(rowsAffected > 1) throw new Exception("UPDATE AFFECTED TOO MANY ROWS");
    }
}
