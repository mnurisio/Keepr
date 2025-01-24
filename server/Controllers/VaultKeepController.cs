namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultKeepController : ControllerBase{

    public VaultKeepController(VaultKeepService vaultKeepService, Auth0Provider auth0Provider)
    {
        _vaultKeepService = vaultKeepService;
        _auth0Provider = auth0Provider;
    }
    private readonly VaultKeepService _vaultKeepService;
    private readonly Auth0Provider _auth0Provider;
}