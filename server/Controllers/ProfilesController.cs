namespace keepr.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase{

    public ProfilesController(ProfilesService profilesService, Auth0Provider auth0Provider)
    {
        _profilesService = profilesService;
        _auth0Provider = auth0Provider;
    }
    private readonly ProfilesService _profilesService;
    private readonly Auth0Provider _auth0Provider;


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

}