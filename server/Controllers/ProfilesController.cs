using System.Globalization;

namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase{

    public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider, KeepsService keepsService, VaultsService vaultsService)
    {
        _profilesService = profilesService;
        _auth0Provider = auth0Provider;
        _keepsService = keepsService;
        _vaultsService = vaultsService;
    }
    private readonly ProfilesService _profilesService;
    private readonly Auth0Provider _auth0Provider;
    private readonly KeepsService _keepsService;
    private readonly VaultsService _vaultsService;


    [HttpGet("{profileId}")]
    public async Task<ActionResult<Profile>> GetProfileById(string profileId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext); 
            Profile profile = _profilesService.GetProfileById(profileId);
            return Ok(profile);
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }


    [HttpGet("{profileId}/keeps")]
    public async Task<ActionResult<List<Keep>>> GetProfileKeeps(string profileId){
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext); 
            List<Keep> keeps =  _keepsService.GetProfileKeeps(profileId);
            return Ok(keeps);
            
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetProfileVaults(string profileId){
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext); 
            List<Vault> keeps =  _vaultsService.GetProfileVaults(profileId);
            return Ok(keeps);
            
        }
        catch (Exception error)
        {
            
            return BadRequest(error.Message);
        }
    }


}