
namespace keepr.Services;

public class VaultKeepService{

    public VaultKeepService(VaultKeepRepository repository, VaultsService vaultsService)
    {
        _repository = repository;
        _vaultsService = vaultsService;
    }
    private readonly VaultKeepRepository _repository;
    private readonly VaultsService _vaultsService;

    internal VaultKeepKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
    {
        Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, userId);
        VaultKeepKeep VaultKeepKeep = _repository.CreateVaultKeep(vaultKeepData);

        if(VaultKeepKeep.CreatorId != vault.CreatorId) throw new Exception("YOU CANNOT CREATE A VAULTKEEP FOR SOMEONE ELSE VAULT");

        return VaultKeepKeep;
    }

    internal List<VaultKeepKeep> GetKeepsInPublicVault(int vaultId, string userId)
    {
        _vaultsService.GetVaultById(vaultId, userId);

        List<VaultKeepKeep> keeps = _repository.GetKeepsInPublicVault(vaultId);

        return keeps;


    }
}