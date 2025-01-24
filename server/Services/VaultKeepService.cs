namespace keepr.Services;

public class VaultKeepService{

    public VaultKeepService(VaultKeepRepository repository)
    {
        _repository = repository;
    }
    private readonly VaultKeepRepository _repository;

}