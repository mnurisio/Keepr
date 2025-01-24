namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase{

    public VaultKeepsController(VaultKeepService vaultKeepService, Auth0Provider auth0Provider)
    {
        _vaultKeepService = vaultKeepService;
        _auth0Provider = auth0Provider;
    }
    private readonly VaultKeepService _vaultKeepService;
    private readonly Auth0Provider _auth0Provider;

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vaultKeepData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);     
            vaultKeepData.CreatorId = userInfo.Id;
            VaultKeep VaultKeep = _vaultKeepService.CreateVaultKeep(vaultKeepData, userInfo.Id);
            return Ok(VaultKeep);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }
}