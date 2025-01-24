namespace keepr.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase{

    public VaultsController(Auth0Provider auth0Provider, VaultsService vaultsService)
    {

        _auth0Provider = auth0Provider;
        _vaultsService = vaultsService;
    }
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth0Provider;


    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData){
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.CreateVault(vaultData);
            return Ok(vault);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}