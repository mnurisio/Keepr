
namespace keepr.Services;

public class VaultKeepService{

    public VaultKeepService(VaultKeepRepository repository, VaultsService vaultsService)
    {
        _repository = repository;
        _vaultsService = vaultsService;
    }
    private readonly VaultKeepRepository _repository;
    private readonly VaultsService _vaultsService;

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
    {
        Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, userId);
        VaultKeep vaultKeep = _repository.CreateVaultKeep(vaultKeepData);

        if(vaultKeep.CreatorId != vault.CreatorId) throw new Exception("YOU CANNOT CREATE A VAULTKEEP FOR SOMEONE ELSE VAULT");

        return vaultKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInVault(int vaultId, string userId)
    {
        Vault vault = _vaultsService.GetVaultById(vaultId, userId);

        List<VaultKeepKeep> keeps = _repository.GetKeepsInVault(vaultId);

        if(vault.CreatorId != userId && vault.IsPrivate == true) throw new Exception($"Invalid Vault ID: {vaultId}");

        return keeps;


    }
}