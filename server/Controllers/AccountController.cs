namespace keepr.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly Auth0Provider _auth0Provider;
  private readonly VaultsService _vaultsService;
  private readonly ProfilesService _profilesService;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vaultsService, ProfilesService profilesService)
    {
        _accountService = accountService;
        _auth0Provider = auth0Provider;
        _vaultsService = vaultsService;
        _profilesService = profilesService;
    }

    [HttpGet]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateAccount(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }


  [HttpGet("vaults")]
  public async Task<ActionResult<List<Vault>>> GetAccountVaults()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Vault> vaults = _vaultsService.GetAccountVaults(userInfo?.Id);
      return Ok(vaults);

    }
    catch (Exception error)
    {

      return BadRequest(error.Message);
    }
  }


  [HttpPut]
  public async Task<ActionResult<Profile>> EditAccount([FromBody] Profile accountData){
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Profile account = _accountService.Edit(accountData, userInfo.Id);
      return Ok(account);
      
    }
    catch (Exception error)
    {

      return BadRequest(error.Message);
    }
  }
}
