
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
        Vault Vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, userId);
        VaultKeep VaultKeep = _repository.CreateVaultKeep(vaultKeepData);

        if(VaultKeep.CreatorId != Vault.CreatorId) throw new Exception("YOU CANNOT CREATE A VAULTKEEP FOR SOMEONE ELSE VAULT");

        return VaultKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInPublicVault(int vaultId, string userId)
    {
        _vaultsService.GetVaultById(vaultId, userId);

        List<VaultKeepKeep> keeps = _repository.GetKeepsInPublicVault(vaultId);

        return keeps;


    }
}