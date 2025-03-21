


namespace keepr.Services;

public class VaultsService{

    public VaultsService(VaultsRepository repository)
    {
        _repository = repository;
    }
    private readonly VaultsRepository _repository;

    internal Vault CreateVault(Vault vaultData)
    {
        Vault vault = _repository.CreateVault(vaultData);
        return vault;
    }

    internal Vault GetVaultById(int vaultId, string userId)
    {
        Vault vault = _repository.GetVaultById(vaultId);

        if(vault == null) throw new Exception ($"Invalid Vault Id of {vaultId}");

        if(vault.CreatorId != userId && vault.IsPrivate == true) throw new Exception($"Invalid Vault ID: {vaultId}");

        return vault;
    }

    internal Vault UpdateVault(int vaultId, string userId, Vault vaultData)
    {
        Vault vault = GetVaultById(vaultId, userId);

        if(vault.CreatorId != userId) throw new Exception("YOU CANNOT UPDATE ANOTHER PERSON'S VAULT");

        vault.Name = vaultData.Name ?? vault.Name;
        vault.IsPrivate = vaultData.IsPrivate ?? vault.IsPrivate;

        _repository.UpdateVault(vault);

        return vault;
    }

    internal string DeleteVault(int vaultId, string userId)
    {
        Vault vault = GetVaultById(vaultId, userId);

        if(vault.CreatorId != userId) throw new Exception("YOU CANNOT DELETE ANOTHER PERSON'S VAULT");

        _repository.DeleteVault(vaultId);

        return $"Deleted vault: {vault.Name}";

    }

    internal List<Vault> GetProfileVaults(string profileId)
    {
        List<Vault> vaults = _repository.GetProfileVaults(profileId);
        return vaults.FindAll(vault => vault.CreatorId == profileId && vault.IsPrivate == false);
    }

    internal List<Vault> GetAccountVaults(string userId)
    {
        List<Vault> vaults = _repository.GetAccountVaults(userId);
        return vaults;
    }
}